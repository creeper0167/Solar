using Microsoft.Extensions.DependencyInjection;
using Solar.Application;
using Solar.Application.Services.Interface;
using Solar.Application.Services.Service;
using Solar.Infrastructure.Repository;
using Solar.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solar.Application.Services.Interfaces.User;
using Solar.Application.Services.User;
using Solar.Infrastructure.Repository.Interface.User;
using Solar.Infrastructure.Repository.User;
using Solar.Application.Services.Interfaces;
using Solar.Application.Services;

namespace Solar.Infrastructure.IOC
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection service)
        {
            //services
            service.AddScoped<IEquipmentService, EquipmentService>();

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IEmailService, EmailService>();
            //repositories
            service.AddScoped<IEquipmentRepository, EquipmentRepository>();
            service.AddScoped<IUserRepository, UserRepository>();

            service.AddScoped<IAggregateService, AggregateService>();

            //repositories
            service.AddScoped<IEquipmentRepository, EquipmentRepository>();
            service.AddScoped<IAggregateRepository, AggregateRepository>();

        }
    }
}
