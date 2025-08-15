using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class StoryLogRepository : IStoryLogRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<StoryLogRepository> _logger;

        public StoryLogRepository(AppDbContext context, ILogger<StoryLogRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Guid 기반 조회
        public async Task<StoryLog?> GetByIdAsync(Guid id)
        {
            return await _context.StoryLogs.FindAsync(id);
        }

        // Guid 기반 사용자별 로그 조회
        public async Task<IEnumerable<StoryLog>> GetByUserIdAsync(Guid userId)
        {
            return await _context.StoryLogs
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        // 로그 추가
        public async Task AddAsync(StoryLog storyLog)
        {
            _context.StoryLogs.Add(storyLog);
            await _context.SaveChangesAsync();
            _logger.LogInformation("StoryLog({Id}) 추가 완료", storyLog.Id);
        }

        // 로그 업데이트
        public async Task UpdateAsync(StoryLog storyLog)
        {
            _context.StoryLogs.Update(storyLog);
            await _context.SaveChangesAsync();
            _logger.LogInformation("StoryLog({Id}) 업데이트 완료", storyLog.Id);
        }

        // 엔티티 기반 삭제
        public async Task DeleteAsync(StoryLog storyLog)
        {
            _context.StoryLogs.Remove(storyLog);
            await _context.SaveChangesAsync();
            _logger.LogInformation("StoryLog({Id}) 삭제 완료", storyLog.Id);
        }

        // ID 기반 삭제 오버로드
        public async Task DeleteAsync(Guid id)
        {
            var storyLog = await GetByIdAsync(id);
            if (storyLog is null)
            {
                _logger.LogWarning("StoryLog({Id}) 를 찾을 수 없어 삭제되지 않음", id);
                return;
            }

            await DeleteAsync(storyLog);
        }
    }
}