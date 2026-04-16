using Application.Modules.HumanResources.DTOs.Department;
using Application.Modules.HumanResources.DTOs.Employee;
using Application.Modules.HumanResources.Interfaces.Department;
using Application.Modules.HumanResources.Interfaces.Employee;
using Application.Modules.HumanResources.Services.Department;
using Application.Modules.HumanResources.Services.Employee;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configuration
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));


            // Use the Action<IMapperConfigurationExpression> overload to avoid passing an Assembly
            services.AddAutoMapper(cfg => cfg.AddProfile(new EmployeeProfile()));
            services.AddAutoMapper(cfg => cfg.AddProfile(new DepartmentProfile()));


            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            return services;
        }
    }
}
