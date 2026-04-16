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
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(ApplicationDBContext context) : base(context) { }

        public async Task<Inventory?> GetStockAsync(Guid warehouseId, Guid productId)
        {
            return await _dbSet.FirstOrDefaultAsync(i =>
                i.WarehouseId == warehouseId &&
                i.ProductId == productId);
        }

        public async Task<IEnumerable<Inventory>> GetByWarehouseAsync(Guid warehouseId)
        {
            return await _dbSet
                .Where(i => i.WarehouseId == warehouseId)
                .ToListAsync();
        }
    }
}
