using Solar.Domain.Equipment;
using Solar.Infrastructure.Context;
using Solar.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Infrastructure.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly SolarDbContext _context;
        public EquipmentRepository(SolarDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Equipment> GetAll()
        {
            return _context.Equipments;        
        }
    }
}
