using Solar.Domain.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Infrastructure.Repository.Interface
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetAll();
    }
}
