// 파일 위치: Application/Handlers/TodoQueries/GetTodosHandler.cs

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services;
using Core.Entities;
using Application.Queries.Todo;    // GetTodosQuery 정의된 네임스페이스

namespace Application.Handlers.TodoQueries
{
    public class GetTodosHandler
    {
        private readonly TodoService _todoService;

        public GetTodosHandler(TodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<List<Core.Entities.Todo>> Handle(GetTodosQuery query)
        {
            return await _todoService.GetUserTodosAsync(query.UserId);
        }
    }
}