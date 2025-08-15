using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Api.Dtos;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todo;

        public TodoController(ITodoService todo) => _todo = todo;

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var items = await _todo.GetUserTodosAsync(userId);
            var dto = items.Select(x => new TodoDto { Id = x.Id, Title = x.Title, Description = "", });
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoRequestDto req)
        {
            var todo = await _todo.AddTodoAsync(req.UserId, req.Title);
            return Ok(new TodoDto { Id = todo.Id, Title = todo.Title, Description = "" });
        }

        [HttpPost("{id:guid}/complete")]
        public async Task<IActionResult> Complete(Guid id)
        {
            await _todo.CompleteTodoAsync(id);
            return NoContent();
        }
    }
}
