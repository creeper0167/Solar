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
        public decimal? PowerFeedIn { get; set; }
        public decimal? PowerLoad { get; set; }
        public decimal? PowerBattCharge { get; set; }
        public decimal? PowerPV { get; set; }
        public decimal? PowerOutput { get; set; }    
        public decimal? BattSOC { get; set; }
        public decimal? RateSelfConsumption { get; set; }
        public decimal? RateSelfSufficiency { get; set; }
        public decimal? PowerEVCTotal { get; set; }
        public decimal? PowerOhmpilot { get; set; }
    }
}
