using Quartz;
using Solar.Application.Services.Interfaces.EnergyFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.BackgroundJob
{
    [DisallowConcurrentExecution]
    public class ProcessRequest : IJob
    {
        private readonly IEnergyFlowService _energyFlowService;
        public ProcessRequest(IEnergyFlowService energyFlowService)
        {
            _energyFlowService = energyFlowService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await _energyFlowService.GetFlowData();
        }
    }
}
