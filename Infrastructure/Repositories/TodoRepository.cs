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
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _db;

        public TodoRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Todo?> GetByIdAsync(Guid id)
        {
            return await _db.Todos.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Todo>> GetByUserIdAsync(Guid userId)
        {
            // 인터페이스에 존재하는 기본 사용자별 조회
            return await _db.Todos
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Todo>> GetTodosByUserIdAsync(Guid userId)
        {
            // 서비스에서 호출하는 이름 맞춤 (동일 로직 재사용)
            return await GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await _db.Todos
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task AddAsync(Todo todo)
        {
            await _db.Todos.AddAsync(todo);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Todo todo)
        {
            _db.Todos.Update(todo);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Todo todo)
        {
            _db.Todos.Remove(todo);
            await _db.SaveChangesAsync();
        }
    }
}
