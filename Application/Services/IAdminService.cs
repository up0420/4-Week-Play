using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.Services
{
    public interface IAdminService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<List<Todo>> GetAllTodosAsync();
        Task<List<StoryLog>> GetAllStoriesAsync();
        // 필요 시 모니터링용 DTO 추가
    }
}
