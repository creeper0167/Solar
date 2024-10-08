using Solar.Domain.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Infrastructure.Repository.Interface
{
    public interface IAggregateRepository
    {
        void Add(Aggregate aggregate);
        void SaveChanges();
    }
}
