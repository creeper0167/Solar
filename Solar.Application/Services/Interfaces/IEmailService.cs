using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.Services.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string body);
    }
}
