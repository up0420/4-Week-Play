using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.Services
{
    public interface IStoryService
    {
        Task<List<StoryLog>> GetStoryLogsAsync(Guid userId);
        Task<StoryLog> AddAsync(Guid userId, string title, string content);
    }
}
