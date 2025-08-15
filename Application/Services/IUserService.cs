using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<Guid>> GetAllUserIdsAsync();
    }
}
