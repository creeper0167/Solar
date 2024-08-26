using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.DTOs
{
    public class EquipmentDTO
    {
        public int Id { get; set; }
        public int PowerType{get;set;}
        public string PictureAddress { get; set; }
        public string Description { get; set; }
    }
}
