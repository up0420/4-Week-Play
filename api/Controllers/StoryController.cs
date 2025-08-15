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
    public class StoryController : ControllerBase
    {
        private readonly IStoryService _svc;
        public StoryController(IStoryService svc) => _svc = svc;

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var list = await _svc.GetStoryLogsAsync(userId);
            // 필요 시 DTO로 매핑
            return Ok(list);
        }
    }
}
