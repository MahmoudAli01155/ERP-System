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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDBContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(Guid userId)
        {
            return await _dbSet
                .Where(o => o.CreatedBy == userId.ToString())
                .ToListAsync();
        }

        public async Task<Order?> GetOrderWithItemsAsync(Guid orderId)
        {
            return await _dbSet
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
