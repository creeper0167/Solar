using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.DTOs.User
{
    public class EmailConfirmDTO
    {
        public string userEmail { get; set; }
        public string verifyEmailText { get; set; }
    }
}
