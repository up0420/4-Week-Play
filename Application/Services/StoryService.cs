using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;

namespace Application.Services
{
    public class StoryService : IStoryService
    {
        public async Task<List<StoryLog>> GetStoryLogsAsync(Guid userId)
            => await GetUserStoriesAsync(userId);
        private readonly IStoryRepository _storyRepository;

        public StoryService(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public async Task<List<StoryLog>> GetUserStoriesAsync(Guid userId)
            => (await _storyRepository.GetStoriesByUserIdAsync(userId)).ToList();

        public async Task<StoryLog> AddAsync(Guid userId, string title, string content)
        {
            var story = new StoryLog
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Title = title,
                Content = content,
                CreatedAt = DateTime.UtcNow
            };
            await _storyRepository.AddAsync(story);
            return story;
        }
    }
}
