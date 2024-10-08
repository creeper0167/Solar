using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.DTOs
{
    public class AggregateDTO
    {
        public string PvSystemId { get; set; }
        public DataDTO Data { get; set; }
    }
}
