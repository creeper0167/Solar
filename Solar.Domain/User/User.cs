using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Domain.User
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Addres {  get; set; }
        public string Email { get; set; }
        public string key1 { get; set; }
        public string key2 { get; set; }
        public string Zipcode { get; set; }
        public int Keymessage { get; set; }
    }
}
