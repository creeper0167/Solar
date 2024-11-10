using Microsoft.AspNetCore.Mvc;
using Solar.Application.Services.Interfaces.EnergyFlow;

namespace Solar.Api.Controllers.EnergyFlow.Get

{
    [ApiController]
    [Route("api")]
    public class EnergyFlowController : Controller
    {
        private readonly IEnergyFlowService _energyFlowService;
        public EnergyFlowController(IEnergyFlowService energyFlowService)
        {
            _energyFlowService = energyFlowService;
        }
        [HttpGet("EnergyFlow")]
        public async Task<IActionResult> Get()
        {
            var results = _energyFlowService.GetFlowData();
            return Ok(new
            {
                result = results
            });
        }
    }
}
