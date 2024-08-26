using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Domain.Equipment
{
    public class Equipment : BaseEntity
    {
        public int PowerType { get; set; }
        public string PictureAddress { get; set; }
        public string Description { get; set; }
    }
}
