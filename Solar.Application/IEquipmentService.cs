using Solar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application
{
    public interface IEquipmentService
    {
        IEnumerable<EquipmentDTO> GetAll();
        void Add(EquipmentDTO equipment);
        void SaveChanges();
    }
}
