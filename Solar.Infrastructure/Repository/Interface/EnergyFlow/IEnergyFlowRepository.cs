using Solar.Domain.EnergyFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Infrastructure.Repository.Interface.EnergyFlow
{
    public interface IEnergyFlowRepository
    {

        void Add(EnergyFlowData energyFlow);
        void SaveChanges();
    }
}
