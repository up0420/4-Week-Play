using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;

namespace Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<List<Todo>> GetUserTodosAsync(Guid userId)
            => (await _todoRepository.GetTodosByUserIdAsync(userId)).ToList();

        public async Task<Todo> AddTodoAsync(Guid userId, string title)
        {
            var todo = new Todo
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Title = title,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };
            await _todoRepository.AddAsync(todo);
            return todo;
        }

        public async Task CompleteTodoAsync(Guid todoId)
        {
            var todo = await _todoRepository.GetByIdAsync(todoId);
            if (todo is null) return;

            todo.IsCompleted = true;
            await _todoRepository.UpdateAsync(todo);
        }
    }
}
