using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IFortuneService
    {
        Task<string> GenerateDailyFortuneAsync(Guid userId, DateTime? birthday = null);

        // 컨트롤러 호환용 오버로드
        Task<string> GetTodayFortuneAsync(Guid userId);
        Task<string> GetTodayFortuneAsync(Guid userId, DateTime? birthDate);
        Task<string> GetTodayFortuneAsync(DateTime birthDate);
    }
}
