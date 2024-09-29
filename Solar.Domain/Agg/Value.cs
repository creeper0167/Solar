using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Domain.Agg
{
    public class Value : BaseEntity
    {
        public decimal Total { get; set; }

        public virtual Channel Channel { get; set; }
    }
}
