using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repositories;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<IEnumerable<Guid>> GetAllUserIdsAsync()
            => (await _userRepository.GetAllAsync()).Select(u => u.Id);
    }
}
