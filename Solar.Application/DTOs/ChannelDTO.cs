using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.DTOs
{
    public class ChannelDTO
    {
        public string ChannelName { get; set; }
        public string ChannelType { get; set; }
        public string Unit { get;set; }
        public ValueDTO Values { get; set; }

    }
}
