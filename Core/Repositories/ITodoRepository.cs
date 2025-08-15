using Core.Entities;

namespace Core.Repositories
{
    public interface ITodoRepository
    {
        Task<Todo?> GetByIdAsync(Guid id);
        Task<IEnumerable<Todo>> GetByUserIdAsync(Guid userId);

        // ★ 서비스에서 호출
        Task<IEnumerable<Todo>> GetTodosByUserIdAsync(Guid userId);

        // ★ AdminService에서 호출
        Task<IEnumerable<Todo>> GetAllAsync();

        Task AddAsync(Todo todo);
        Task UpdateAsync(Todo todo);
        Task DeleteAsync(Todo todo);
    }
}
