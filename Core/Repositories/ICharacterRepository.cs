using Core.Entities;

namespace Core.Repositories
{
    public interface ICharacterRepository
    {
        Task<Character?> GetByIdAsync(Guid id);

        // ★ 서비스에서 호출
        Task<IEnumerable<Character>> GetCharactersByUserIdAsync(Guid userId);

        Task AddAsync(Character character);
        Task UpdateAsync(Character character);
        Task DeleteAsync(Character character);
    }
}
