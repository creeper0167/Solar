using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.DTOs.EnergyFlow
{
    public class EnergyFlowChannelDTO
    {
        public string ChannelName { get; set; }
        public string ChannelType { get; set; }
        public string Unit { get; set; }
        public decimal? Value { get; set; }
    }
}
