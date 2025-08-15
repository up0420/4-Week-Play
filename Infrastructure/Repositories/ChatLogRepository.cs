// 파일 위치: Infrastructure/Repositories/ChatLogRepository.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ChatLogRepository : IChatLogRepository
    {
        private readonly AppDbContext _context;

        public ChatLogRepository(AppDbContext context)
        {
            _context = context;
        }

        // GUID 기반 단건 조회
        public async Task<ChatLog?> GetByIdAsync(Guid id)
        {
            return await _context.ChatLogs.FindAsync(id);
        }

        // 사용자별 전체 조회
        public async Task<IEnumerable<ChatLog>> GetByUserIdAsync(Guid userId)
        {
            return await _context.ChatLogs
                                 .Where(c => c.UserId == userId)
                                 .ToListAsync();
        }

        // 새 로그 추가
        public async Task AddAsync(ChatLog chatLog)
        {
            await _context.ChatLogs.AddAsync(chatLog);
            await _context.SaveChangesAsync();
        }

        // 기존 로그 업데이트
        public async Task UpdateAsync(ChatLog chatLog)
        {
            _context.ChatLogs.Update(chatLog);
            await _context.SaveChangesAsync();
        }

        // 엔티티 인스턴스 기반 삭제
        public async Task DeleteAsync(ChatLog chatLog)
        {
            _context.ChatLogs.Remove(chatLog);
            await _context.SaveChangesAsync();
        }

        // ID 기반 삭제 오버로드
        public async Task DeleteAsync(Guid id)
        {
            var log = await GetByIdAsync(id);
            if (log != null)
            {
                await DeleteAsync(log);
            }
        }
    }
}