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
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(ApplicationDBContext context) : base(context) { }

        public async Task<bool> IsNameExistsAsync(string name)
        {
            return await _dbSet.AnyAsync(w => w.EnName == name || w.ArName == name);
        }

        public async Task<Warehouse?> GetWithInventoryAsync(Guid id)
        {
            return await _dbSet
                .Include(w => w.Inventories)
                .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}
