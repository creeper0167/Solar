using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.DTOs.EnergyFlow
{
    public class EnergyFlowDTO
    {
        public string PvSystemId { get; set; }
        public EnergyFlowDataDTO Data { get; set; }
    }
}
