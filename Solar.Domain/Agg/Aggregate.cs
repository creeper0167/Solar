using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Domain.Agg
{
    public class Aggregate : BaseEntity
    {
        public string PvSystemId { get; set; }
        public string ChannelName { get; set; }
        public string ChannelType { get; set; }
        public string Unit { get; set; }
        public decimal Total { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
