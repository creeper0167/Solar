using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solar.Application.DTOs.User;
using Solar.Application.Services.Interface;
using Solar.Application.Services.Interfaces.EnergyFlow;

namespace Solar.Api.Controllers.Dashboard
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly IEnergyFlowService _energyFlowService;
        private readonly IAggregateService _aggregateService;
        public DashboardController(IEnergyFlowService energyFlowService, IAggregateService aggregateService)
        {
            _energyFlowService = energyFlowService;
            _aggregateService = aggregateService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var aggregate = _aggregateService.GetLast(); //TODO: ورودی پذیرد
            var energyFlow = _energyFlowService.GetLast(); //TODO: ورودی پذیرد

            return Ok(new
            {
                Earnings = aggregate.Earnings,
                Profits = aggregate.Profits,
                Savings = aggregate.Savings,
                SavingCO2 = aggregate.SavingsCO2,
                PowerPv = energyFlow.PowerPV
            });
        }


        [HttpPut]
        public async Task<IActionResult> Edit(UserUpdateDTO userUpdateDTO)
        {
            return Ok();
        }
    }
}
