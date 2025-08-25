using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Api.Dtos;
using System.Collections.Generic; // List<string>

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FortuneController : ControllerBase
    {
        private readonly IFortuneService _svc;
        public FortuneController(IFortuneService svc) => _svc = svc;

        [HttpPost("today")]
        public async Task<IActionResult> Today([FromBody] FortuneRequestDto req)
        {
            var fortune = req.UserId.HasValue
                ? await _svc.GetTodayFortuneAsync(req.UserId.Value, req.BirthDate)
                : (req.BirthDate.HasValue
                    ? await _svc.GetTodayFortuneAsync(req.BirthDate.Value)
                    : await _svc.GetTodayFortuneAsync(System.Guid.Empty));

            return Ok(new FortuneResponseDto
            {
                TodayFortune = fortune,
                Keywords = new List<string>() // List<string>로 타입 일치
            });
        }
    }
}
