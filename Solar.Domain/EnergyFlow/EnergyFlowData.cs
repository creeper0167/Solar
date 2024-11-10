using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Domain.EnergyFlow
{
    public class EnergyFlowData : BaseEntity
    {
        public string ChannelName { get; set; }
        public string Unit { get; set; }    
        public string ChannelType { get; set; }
        public decimal Value { get; set; }
        
    }
}
