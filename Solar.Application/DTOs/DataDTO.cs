using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.DTOs
{
    public class DataDTO
    {
        public LogPeriodDTO LogPeriod { get; set; }
        public List<ChannelDTO> Channels { get; set; }
    }
}
