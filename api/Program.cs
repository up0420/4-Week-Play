using Microsoft.EntityFrameworkCore;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// ─── DB (MariaDB) ─────────────────────────────────────────────────────────────
builder.Services.AddDbContext<TodoDb>(opt =>
    opt.UseMySql(
        builder.Configuration.GetConnectionString("Maria"),
        new MySqlServerVersion(new Version(11, 0))));

// ─── Hangfire ─────────────────────────────────────────────────────────────────
builder.Services.AddHangfire(cfg => cfg.UseMemoryStorage());
builder.Services.AddHangfireServer();

// ─── SignalR ──────────────────────────────────────────────────────────────────
builder.Services.AddSignalR();

// ─── Swagger ──────────────────────────────────────────────────────────────────
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHangfireDashboard();        // http://localhost:5000/hangfire
}

// ─── CRUD Todo Endpoints ──────────────────────────────────────────────────────
app.MapGet("/todos", async (TodoDb db)
    => await db.Todos.OrderBy(t => t.Id).ToListAsync());

app.MapGet("/todos/{id:int}", async (int id, TodoDb db)
    => await db.Todos.FindAsync(id) is Todo t ? Results.Ok(t) : Results.NotFound());

app.MapPost("/todos", async (Todo todo, TodoDb db, IHubContext<TodoHub> hub) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    await hub.Clients.All.SendAsync("TodoAdded", todo);   // 실시간 브로드캐스트
    return Results.Created($"/todos/{todo.Id}", todo);
});

app.MapPut("/todos/{id:int}", async (int id, Todo input, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();
    todo.Title  = input.Title;
    todo.IsDone = input.IsDone;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/todos/{id:int}", async (int id, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();
    db.Todos.Remove(todo);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// ─── Hangfire 테스트 ──────────────────────────────────────────────────────────
app.MapPost("/jobs/ping", (IBackgroundJobClient jobs) =>
{
    jobs.Enqueue(() => Console.WriteLine("🔔 Ping from Hangfire!"));
    return Results.Ok("Queued");
});

// ─── SignalR Hub ──────────────────────────────────────────────────────────────
app.MapHub<TodoHub>("/hubs/todo");

// 기본 헬스 체크
app.MapGet("/", () => "4WeekPlay API ready");

app.Run();

// ─── EF Core Context & Model ──────────────────────────────────────────────────
public class TodoDb(DbContextOptions<TodoDb> opts) : DbContext(opts)
{
    public DbSet<Todo> Todos => Set<Todo>();
}
public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; }
}

// ─── SignalR Hub ──────────────────────────────────────────────────────────────
public class TodoHub : Hub { }
