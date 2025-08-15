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
    public class CharacterRepository : ICharacterRepository
    {
        private readonly AppDbContext _db;

        public CharacterRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Character?> GetByIdAsync(Guid id)
        {
            return await _db.Characters
                // 필요 시 연관 로딩:
                // .Include(c => c.ChatLogs)
                // .Include(c => c.Simulations)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Character>> GetCharactersByUserIdAsync(Guid userId)
        {
            return await _db.Characters
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(Character character)
        {
            await _db.Characters.AddAsync(character);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Character character)
        {
            _db.Characters.Update(character);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Character character)
        {
            _db.Characters.Remove(character);
            await _db.SaveChangesAsync();
        }
    }
}
