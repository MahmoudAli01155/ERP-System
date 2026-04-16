using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StockMovement : BaseEntity
    {
        public Guid ProductId { get; private set; }
        public Guid WarehouseId { get; private set; }

        public MovementType Type { get; private set; }
        public int Quantity { get; private set; }

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        // 🔥 EF Core constructor (IMPORTANT)
        private StockMovement() { }

        // Business constructor
        public StockMovement(Guid productId, Guid warehouseId, MovementType type, int qty)
        {
            ProductId = productId;
            WarehouseId = warehouseId;
            Type = type;
            Quantity = qty;
        }
    }
}
