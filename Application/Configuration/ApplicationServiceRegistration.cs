using Application.Modules.HumanResources.DTOs.Attendanc;
using Application.Modules.HumanResources.DTOs.Department;
using Application.Modules.HumanResources.DTOs.Employee;
using Application.Modules.HumanResources.DTOs.Leave;
using Application.Modules.HumanResources.DTOs.Payroll;
using Application.Modules.HumanResources.Interfaces.Attendanc;
using Application.Modules.HumanResources.Interfaces.Department;
using Application.Modules.HumanResources.Interfaces.Employee;
using Application.Modules.HumanResources.Interfaces.Leave;
using Application.Modules.HumanResources.Interfaces.Payroll;
using Application.Modules.HumanResources.Services.Attendanc;
using Application.Modules.HumanResources.Services.Department;
using Application.Modules.HumanResources.Services.Employee;
using Application.Modules.HumanResources.Services.Leave;
using Application.Modules.HumanResources.Services.Payroll;
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
            services.AddAutoMapper(cfg => cfg.AddProfile(new LeaveProfile()));
            services.AddAutoMapper(cfg => cfg.AddProfile(new PayrollProfile()));


            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<ILeaveService, LeaveService>();
            services.AddScoped<IPayrollService, PayrollService>();

            return services;
        }
    }
}
