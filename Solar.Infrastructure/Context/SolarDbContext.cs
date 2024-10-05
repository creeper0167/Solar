using Microsoft.EntityFrameworkCore;
using Solar.Domain.Agg;
using Solar.Domain.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Infrastructure.Context
{
    public class SolarDbContext : DbContext
    {
        public SolarDbContext(DbContextOptions<SolarDbContext> options) : base(options)
        {
            
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Aggregate> Aggregates { get; set; }
    }
}
