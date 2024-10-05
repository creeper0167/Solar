using Solar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.Services.Interface
{
    public interface IAggregateService
    {
        void AddAggregate(AggregateSubmitDTO aggregateDTO);
        void SaveChanges();
    }
}
