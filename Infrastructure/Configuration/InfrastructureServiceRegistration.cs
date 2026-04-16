using Domain.Interfaces;
using Infrastructure.Persistence.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            // ================= DbContext =================
            services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));



            // ================= Generic Repository =================
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



            // ================= Unit Of Work ==============================
            services.AddScoped<IUnitOfWork, UnitOfWork>();



            // ================= HR Repositories =================
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<IPayrollRepository, PayrollRepository>();

            // ================= E-Commerce Repositories =================
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            // ================= Supply Chain Repositories =================
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IStockMovementRepository, StockMovementRepository>();
            services.AddScoped<IShipmentRepository, ShipmentRepository>();



            return services;
        }
    }
}
