using Solar.Domain.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Domain.Equipment
{
    public class Equipment : BaseEntity
    {
        [ForeignKey("User")]
        public int UserId {  get; set; }
        public string? PvSystemId { get; set; }
        public int? PowerType { get; set; }
        public string? PictureAddress { get; set; }
        public string? Description { get; set; }
        public int? Keyuser { get; set; }

        public virtual User.User User { get; set; }
    }
}
