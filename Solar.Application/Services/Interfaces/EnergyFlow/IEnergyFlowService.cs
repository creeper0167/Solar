using Microsoft.AspNetCore.Mvc;
using Solar.Application.DTOs.EnergyFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.Services.Interfaces.EnergyFlow
{
    public interface IEnergyFlowService
    {
        public Task<ActionResult<EnergyFlowDTO>> GetFlowData();
    }
}
