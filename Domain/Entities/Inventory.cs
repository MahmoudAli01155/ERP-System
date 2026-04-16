using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inventory : BaseEntity
    {
        public Guid WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; private set; }

        // 🔥 EF Core constructor (IMPORTANT)
        private Inventory() { }

        // Business constructor
        public Inventory(Guid productId, Guid warehouseId, int qty)
        {
            ProductId = productId;
            WarehouseId = warehouseId;
            Quantity = qty;
        }

        public void Increase(int qty)
        {
            if (qty <= 0) throw new Exception("Invalid qty");
            Quantity += qty;
        }

        public void Decrease(int qty)
        {
            if (qty <= 0) throw new Exception("Invalid qty");
            if (Quantity < qty) throw new Exception("Not enough stock");

            Quantity -= qty;
        }
    }
}
