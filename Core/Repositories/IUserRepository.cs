using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IUserRepository
    {
        // Guid로 변경하고, 조회 시 없을 수도 있으므로 nullable 반환으로 조정
        Task<User?> GetByIdAsync(Guid id);

        Task<User?> GetByEmailAsync(string email);

        Task<IEnumerable<User>> GetAllAsync();

        Task AddAsync(User user);

        Task UpdateAsync(User user);

        Task DeleteAsync(User user);
    }
}