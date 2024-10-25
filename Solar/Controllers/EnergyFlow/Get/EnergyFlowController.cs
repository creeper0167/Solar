using Microsoft.AspNetCore.Mvc;

namespace Solar.Api.Controllers.EnergyFlow.Get

{
    [ApiController]
    [Route("api")]
    public class EnergyFlowController : Controller
    {
        [HttpGet("EnergyFlow")]
        public IActionResult Get()
        {
            return View();
        }
    }
}
