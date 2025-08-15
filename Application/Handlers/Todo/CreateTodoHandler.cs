using System.Threading.Tasks;
using Application.Services;

// ★ Core.Entities.Todo 를 별칭으로 지정
using TodoEntity = Core.Entities.Todo;

namespace Application.Handlers.Todo
{
    public class CreateTodoHandler
    {
        private readonly TodoService _todoService;

        public CreateTodoHandler(TodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<TodoEntity> Handle(CreateTodoCommand command)
        {
            return await _todoService.AddTodoAsync(command.UserId, command.Title);
        }
    }
}
