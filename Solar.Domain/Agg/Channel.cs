using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Domain.Agg
{
    public class Channel : BaseEntity
    {
        public string ChannelName { get; set; }
        public string ChannelType { get; set; }
        public string Unit { get; set; }
        public virtual List<Value> Values { get; set; }
    }
}
