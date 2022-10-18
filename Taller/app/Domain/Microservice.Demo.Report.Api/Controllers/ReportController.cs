using Microservice.Demo.Report.Api.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Microservice.Demo.Report.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ReportApplicationService _reportApplicationService;
        private readonly ILogger<ReportController> _logger;
        public ReportController(ReportApplicationService reportApplicationService, ILogger<ReportController> logger)
        {
            _reportApplicationService = reportApplicationService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _reportApplicationService.GetAllAsync();
            return new JsonResult(result);
        }
    }
}
