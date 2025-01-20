using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.DTOs.EnergyFlow
{
    public class EnergyFlowDataDTO
    {
        public string logDateTime { get; set; }
        public List<EnergyFlowChannelDTO> Channels { get; set; }
    }
}
