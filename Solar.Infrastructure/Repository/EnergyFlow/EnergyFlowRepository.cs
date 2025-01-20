using Solar.Domain.EnergyFlow;
using Solar.Infrastructure.Context;
using Solar.Infrastructure.Repository.Interface.EnergyFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Infrastructure.Repository.EnergyFlow
{
    public class EnergyFlowRepository : IEnergyFlowRepository 
    {
        private readonly SolarDbContext _context;
        public EnergyFlowRepository(SolarDbContext context)
        {
            _context = context;
        }
        public void Add(EnergyFlowData energyFlow)
        {
            _context.EnergyFlowDatas.Add(energyFlow);
        }

        public EnergyFlowData GetLast()
        {
            return _context.EnergyFlowDatas.OrderByDescending(i => i.Id).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
