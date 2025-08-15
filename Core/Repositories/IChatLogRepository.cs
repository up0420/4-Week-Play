using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IChatLogRepository
    {
        Task<ChatLog?> GetByIdAsync(Guid id);
        Task<IEnumerable<ChatLog>> GetByUserIdAsync(Guid userId);
        Task AddAsync(ChatLog chatLog);
        Task UpdateAsync(ChatLog chatLog);
        Task DeleteAsync(ChatLog chatLog);
        Task DeleteAsync(Guid id);
    }
}