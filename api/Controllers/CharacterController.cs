using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Core.Enums;
using Api.Dtos;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _svc;
        public CharacterController(ICharacterService svc) => _svc = svc;

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var list = await _svc.GetUserCharactersAsync(userId);
            var dto = list.Select(c => new CharacterDto { Id = c.Id, Name = c.Name });
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCharacterRequestDto req)
        {
            var ch = await _svc.CreateCharacterAsync(req.UserId, req.Type, req.Name);
            return Ok(new CharacterDto { Id = ch.Id, Name = ch.Name });
        }
    }
}
