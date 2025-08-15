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
    public class SimulationController : ControllerBase
    {
        private readonly ISimulationService _svc;
        public SimulationController(ISimulationService svc) => _svc = svc;

        [HttpPost("start")]
        public async Task<IActionResult> Start([FromBody] StartSimulationRequestDto req)
        {
            var sim = await _svc.StartSimulationAsync(req.UserId, req.CharacterId, req.Type, req.OptionsJson);
            return Ok(new SimulationResultDto { ResultSummary = "Started" });
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> List(Guid userId)
        {
            var sims = await _svc.GetUserSimulationsAsync(userId);
            return Ok(sims);
        }
    }
}
