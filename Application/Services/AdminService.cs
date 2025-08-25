using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _users;
        private readonly ITodoRepository _todos;
        private readonly IStoryRepository _stories;

        public AdminService(IUserRepository users, ITodoRepository todos, IStoryRepository stories)
        {
            _users = users; _todos = todos; _stories = stories;
        }

        public async Task<List<User>> GetAllUsersAsync()  => (await _users.GetAllAsync()).ToList();
        public async Task<List<Todo>> GetAllTodosAsync()  => (await _todos.GetAllAsync()).ToList();
        public async Task<List<StoryLog>> GetAllStoriesAsync() => (await _stories.GetAllAsync()).ToList();

        // ★ 컨트롤러에서 호출하는 모니터링 메서드
        public async Task<object> GetMonitoringDataAsync()
        {
            var users   = (await _users.GetAllAsync()).Count();
            var todos   = (await _todos.GetAllAsync()).Count();
            var stories = (await _stories.GetAllAsync()).Count();
            return new { users, todos, stories };
        }

        // 신규 오버로드: Controller에서 전달한 CancellationToken 수용
        public Task<object> GetMonitoringDataAsync(CancellationToken cancellationToken)
        {
            // 내부 구현이 cancellationToken을 아직 사용하지 않으면 그대로 위임
            return GetMonitoringDataAsync();
        }
    }
}
