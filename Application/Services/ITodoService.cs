using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetUserTodosAsync(Guid userId);
        Task<Todo> AddTodoAsync(Guid userId, string title);
        Task CompleteTodoAsync(Guid todoId);
    }
}
