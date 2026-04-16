using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Warehouse : BaseEntity
    {
        private readonly List<Inventory> _inventories = new();
        //public IReadOnlyCollection<Inventory> Inventories => _inventories;

        public string ArName { get; private set; } = null!;
        public string EnName { get; private set; } = null!;
        public string Location { get; private set; } = null!;
        public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

        public Warehouse(string arName, string enName, string location)
        {
            if (string.IsNullOrWhiteSpace(arName))
                throw new Exception("Arabic name is required");

            if (string.IsNullOrWhiteSpace(enName))
                throw new Exception("English name is required");

            ArName = arName;
            EnName = enName;
            Location = location;
        }

        public void StockIn(Guid productId, int qty)
        {
            var item = _inventories.FirstOrDefault(x => x.ProductId == productId);

            if (item == null)
            {
                _inventories.Add(new Inventory(productId, Id, qty));
                return;
            }

            item.Increase(qty);
        }

        public void StockOut(Guid productId, int qty)
        {
            var item = _inventories.FirstOrDefault(x => x.ProductId == productId);

            if (item == null || item.Quantity < qty)
                throw new Exception("Insufficient stock");

            item.Decrease(qty);
        }
    }
}
