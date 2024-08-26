using Microsoft.Extensions.DependencyInjection;
using Solar.Application;
using Solar.Infrastructure.Repository;
using Solar.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Infrastructure.IOC
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection service)
        {
            //services
            service.AddScoped<IEquipmentService, EquipmentService>();


            //repositories
            service.AddScoped<IEquipmentRepository, EquipmentRepository>();
        }
    }
}
