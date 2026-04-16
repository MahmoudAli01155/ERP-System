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
    public class StockMovementRepository : Repository<StockMovement>, IStockMovementRepository
    {
        public StockMovementRepository(ApplicationDBContext context) : base(context) { }

        public async Task<IEnumerable<StockMovement>> GetByProductAsync(Guid productId)
        {
            return await _dbSet
                .Where(m => m.ProductId == productId)
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockMovement>> GetByDateRangeAsync(DateTime from, DateTime to)
        {
            return await _dbSet
                .Where(m => m.CreatedAt >= from && m.CreatedAt <= to)
                .ToListAsync();
        }
    }
}
