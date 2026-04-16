using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private readonly ApplicationDBContext _context;

        public PaymentRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Payment?> GetByOrderIdAsync(Guid orderId)
        {
            return await _context.Payments
                .FirstOrDefaultAsync(p => p.OrderId == orderId);
        }

        public async Task<bool> IsOrderPaidAsync(Guid orderId)
        {
            return await _context.Payments
                .AnyAsync(p => p.OrderId == orderId);
        }
    }
}
