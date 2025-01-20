using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.DTOs
{
    public class AggregateYearDTO
    {
        public string PvSystemId { get; set; }
        public string ChannelName { get; set; }
        public string ChannelType { get; set; }
        public string Unit { get; set; }
        public string Year { get; set; }
    }
}
