// Program.cs
using Core.External;
using Infrastructure.External;

using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;              // ServerVersion.AutoDetect
using Microsoft.OpenApi.Models;


using Infrastructure.Data;
using Hangfire;
using Hangfire.MemoryStorage;

using Api.Hubs;                                      // NotificationHub
using Api.Jobs;                                      // DailyFortuneJob

var builder = WebApplication.CreateBuilder(args);

// ===== MVC & Swagger =====
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo { Title = "4WeekPlay API", Version = "v1" });
});

// ===== DB (Pomelo AutoDetect) =====
var conn = builder.Configuration.GetConnectionString("Maria")
           ?? throw new InvalidOperationException("Missing connection string 'Maria'.");
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseMySql(conn, ServerVersion.AutoDetect(conn)));

// ===== Hangfire =====
builder.Services.AddHangfire(cfg => cfg.UseMemoryStorage());
builder.Services.AddHangfireServer();

// ===== SignalR =====
builder.Services.AddSignalR();

// ===================== DI 등록 (비제네릭 typeof 오버로드) =====================
// Application Services
builder.Services.AddScoped(
    typeof(Application.Services.IFortuneService),
    typeof(Application.Services.FortuneService));

builder.Services.AddScoped(
    typeof(Application.Services.ICharacterService),
    typeof(Application.Services.CharacterService));

builder.Services.AddScoped(
    typeof(Application.Services.IChatService),
    typeof(Application.Services.ChatService));

builder.Services.AddScoped(
    typeof(Application.Services.ISimulationService),
    typeof(Application.Services.SimulationService));

builder.Services.AddScoped(
    typeof(Application.Services.ITodoService),
    typeof(Application.Services.TodoService));

// NotificationService: 구현체를 먼저 등록해두고…
builder.Services.AddScoped(typeof(Application.Services.NotificationService));
// …인터페이스는 팩토리로 매핑 (캐시/섀도잉 이슈 회피)
builder.Services.AddScoped<Application.Services.INotificationService>(sp =>
    sp.GetRequiredService<Application.Services.NotificationService>());

builder.Services.AddScoped(
    typeof(Application.Services.IStoryService),
    typeof(Application.Services.StoryService));

builder.Services.AddScoped(
    typeof(Application.Services.IAdminService),
    typeof(Application.Services.AdminService));

builder.Services.AddScoped(
    typeof(Application.Services.IUserService),
    typeof(Application.Services.UserService));

// Repositories
builder.Services.AddScoped(
    typeof(Core.Repositories.IUserRepository),
    typeof(Infrastructure.Repositories.UserRepository));

builder.Services.AddScoped(
    typeof(Core.Repositories.ICharacterRepository),
    typeof(Infrastructure.Repositories.CharacterRepository));

builder.Services.AddScoped(
    typeof(Core.Repositories.ITodoRepository),
    typeof(Infrastructure.Repositories.TodoRepository));

// 구현됐으면 주석 해제
// builder.Services.AddScoped(
//     typeof(Core.Repositories.IStoryRepository),
//     typeof(Infrastructure.Repositories.StoryRepository));

// External (SignalR wrapper)
builder.Services.AddScoped(
    typeof(Core.External.ISignalRService),
    typeof(Api.Services.SignalRService));

// Jobs
builder.Services.AddTransient<DailyFortuneJob>();

builder.Services.AddHttpClient<ILlmClient, OpenAIService>(c =>
{
    c.BaseAddress = new Uri("https://api.openai.com/v1/");
});


var app = builder.Build();

// ===== Middleware =====
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHangfireDashboard();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// SignalR Hub
app.MapHub<NotificationHub>("/hubs/notify");

// Hangfire: 매일 08:00 실행
using (var scope = app.Services.CreateScope())
{
    var mgr = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
    var job = scope.ServiceProvider.GetRequiredService<DailyFortuneJob>();
    mgr.AddOrUpdate("DailyFortuneJob", () => job.RunAsync(), "0 8 * * *");
}

// Health check
app.MapGet("/", () => "4WeekPlay API ready");

app.Run();
