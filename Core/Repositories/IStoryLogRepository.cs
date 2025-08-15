using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IStoryLogRepository
    {
        Task<StoryLog?> GetByIdAsync(Guid id);               // Guid로 변경
        Task<IEnumerable<StoryLog>> GetByUserIdAsync(Guid userId); // Guid로 변경
        Task AddAsync(StoryLog storyLog);
        Task UpdateAsync(StoryLog storyLog);
        Task DeleteAsync(StoryLog storyLog);                 // 엔티티 기반 삭제
    }
}