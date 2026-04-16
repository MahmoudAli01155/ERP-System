using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Interfaces;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<UnitOfWork> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IEmployeeRepository EmployeeRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public IAttendanceRepository AttendanceRepository { get; }
        public ILeaveRepository LeaveRepository { get; }
        public IPayrollRepository PayrollRepository { get; }

        // E-Commerce
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ICartRepository CartRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IPaymentRepository PaymentRepository { get; }

        // Supply Chain
        public IWarehouseRepository WarehouseRepository { get; }
        public IInventoryRepository InventoryRepository { get; }
        public IStockMovementRepository StockMovementRepository { get; }
        public IShipmentRepository ShipmentRepository { get; }

        public UnitOfWork(
            ApplicationDBContext context,
            ILogger<UnitOfWork> logger,
            IHttpContextAccessor httpContextAccessor,
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            IAttendanceRepository attendanceRepository,
            ILeaveRepository leaveRepository,
            IPayrollRepository payrollRepository)
        {
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;

            EmployeeRepository = employeeRepository;
            DepartmentRepository = departmentRepository;
            AttendanceRepository = attendanceRepository;
            LeaveRepository = leaveRepository;
            PayrollRepository = payrollRepository;
        }


        public async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                var userId = _httpContextAccessor
                    .HttpContext?
                    .User?
                    .Identity?
                    .Name ?? "System";

                foreach (var entry in _context.ChangeTracker
                    .Entries<BaseEntity>())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedAt = DateTime.UtcNow;
                            entry.Entity.CreatedBy = userId;
                            break;

                        case EntityState.Modified:
                            entry.Entity.ModifiedAt = DateTime.UtcNow;
                            entry.Entity.ModifiedBy = userId;
                            break;
                    }
                }

                _logger.LogInformation(
                    "Committing transaction by user {User}",
                    userId);

                var result = await _context
                    .SaveChangesAsync(cancellationToken);

                _logger.LogInformation(
                    "Transaction committed successfully. Rows affected: {Count}",
                    result);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error occurred during transaction commit");

                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
