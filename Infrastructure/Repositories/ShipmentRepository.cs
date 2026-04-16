using Domain.Entities;
using Domain.Enums;
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
    public class ShipmentRepository : Repository<Shipment>, IShipmentRepository
    {
        public ShipmentRepository(ApplicationDBContext context) : base(context) { }

        public async Task<IEnumerable<Shipment>> GetByStatusAsync(ShipmentStatus status)
        {
            return await _dbSet
                .Where(s => s.Status == status)
                .ToListAsync();
        }

        public async Task<Shipment?> GetWithOrderAsync(Guid id)
        {
            return await _dbSet
                .Include(s => s.OrderId)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
