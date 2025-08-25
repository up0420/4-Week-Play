using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _svc; // concrete 사용
        public AdminController(AdminService svc) => _svc = svc;

        [HttpGet("monitor")]
        public async Task<IActionResult> Monitor(CancellationToken cancellationToken)
        {
            var data = await _svc.GetMonitoringDataAsync(cancellationToken);
            return Ok(data);
        }
    }
}
