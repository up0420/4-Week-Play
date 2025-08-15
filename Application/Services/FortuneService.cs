using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FortuneService : IFortuneService
    {
        public Task<string> GenerateDailyFortuneAsync(Guid userId, DateTime? birthday = null)
            => Task.FromResult("오늘의 운세: 좋은 하루 보내세요!");

        // 컨트롤러에서 찾는 이름들 맞춰서 오버로드 제공
        public Task<string> GetTodayFortuneAsync(Guid userId)
            => GenerateDailyFortuneAsync(userId, null);

        public Task<string> GetTodayFortuneAsync(Guid userId, DateTime? birthDate)
            => GenerateDailyFortuneAsync(userId, birthDate);

        public Task<string> GetTodayFortuneAsync(DateTime birthDate)
            => Task.FromResult("오늘의 운세: 좋은 하루 보내세요!");
    }
}
