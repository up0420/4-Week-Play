using Core.Entities;

namespace Core.Repositories
{
    public interface IStoryRepository
    {
        Task<StoryLog?> GetByIdAsync(Guid storyId);

        // ★ StoryService에서 호출
        Task<IEnumerable<StoryLog>> GetStoriesByUserIdAsync(Guid userId);

        // ★ AdminService에서 호출
        Task<IEnumerable<StoryLog>> GetAllAsync();

        Task AddAsync(StoryLog story);
        Task UpdateAsync(StoryLog story);
        Task DeleteAsync(StoryLog story);
    }
}
