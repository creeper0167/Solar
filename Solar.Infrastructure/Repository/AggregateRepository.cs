using Solar.Domain.Agg;
using Solar.Infrastructure.Context;
using Solar.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Infrastructure.Repository
{
    public class AggregateRepository : IAggregateRepository
    {
        SolarDbContext _context;
        public AggregateRepository(SolarDbContext context)
        {
            _context = context;
        }
        public void Add(Aggregate aggregate)
        {
            _context.Aggregates.Add(aggregate);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
