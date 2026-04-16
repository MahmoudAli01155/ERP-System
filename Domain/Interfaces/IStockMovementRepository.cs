using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStockMovementRepository : IRepository<StockMovement>
    {
        Task<IEnumerable<StockMovement>> GetByProductAsync(Guid productId);

        Task<IEnumerable<StockMovement>> GetByDateRangeAsync(DateTime from, DateTime to);
    }
}
