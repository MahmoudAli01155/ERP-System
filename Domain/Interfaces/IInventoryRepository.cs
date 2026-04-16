using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<Inventory?> GetStockAsync(Guid warehouseId, Guid productId);

        Task<IEnumerable<Inventory>> GetByWarehouseAsync(Guid warehouseId);
    }
}
