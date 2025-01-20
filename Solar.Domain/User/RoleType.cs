using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Domain.User
{
    public class RoleType : BaseEntity
    {
        public string RoleName { get; private set; }
        public virtual List<User> User { get; set; }
    }
}
