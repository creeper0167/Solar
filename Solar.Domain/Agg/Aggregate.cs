using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Domain.Agg
{
    public class Aggregate : BaseEntity
    {
        //public string PvSystemId { get; set; }
        public decimal EnergyOutput { get; set; }
        public decimal EnergyDirectConsumption { get; set; }
        public decimal EnergyProductionTotal { get; set; }
        public decimal EnergySelfConsumptionTotal { get; set; }
        public decimal EnergyConsumptionTotal { get; set; }
        public decimal SavingsCO2 { get; set; }
        public decimal SavingsTrees { get; set; }
        public decimal SavingsTravelCar { get; set; }
        public decimal SavingsTravelPlane { get; set; }
        public decimal Profits { get; set; }
        public decimal Earnings { get; set; }
        public decimal Savings { get; set; }
        public decimal Total { get; set; }
        public DateTime LogDateTime { get; set; }
    }
}
