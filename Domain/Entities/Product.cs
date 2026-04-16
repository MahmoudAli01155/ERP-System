using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ArName { get; private set; } = null!;
        public string EnName { get; private set; } = null!;
        public string Description { get; private set; } = null!;

        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }

        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; } = null!;
        public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();


        // 🔥 EF Core constructor (IMPORTANT)
        private Product() { }

        // Business constructor
        public Product(string arName, string enName, string desc, decimal price, int stock, Guid categoryId)
        {
            if (price <= 0)
                throw new Exception("Price must be greater than zero");

            if (stock < 0)
                throw new Exception("Stock cannot be negative");

            ArName = arName;
            EnName = enName;
            Description = desc;
            Price = price;
            StockQuantity = stock;
            CategoryId = categoryId;
        }

        public void Update(string arName, string enName, string desc, decimal price, int stock)
        {
            if (price <= 0)
                throw new Exception("Invalid price");

            if (stock < 0)
                throw new Exception("Invalid stock");

            ArName = arName;
            EnName = enName;
            Description = desc;
            Price = price;
            StockQuantity = stock;

            ModifiedAt = DateTime.UtcNow;
        }

        public void DeductStock(int quantity)
        {
            if (quantity > StockQuantity)
                throw new Exception("Insufficient stock");

            StockQuantity -= quantity;
        }

        public void AddStock(int quantity)
        {
            StockQuantity += quantity;
        }
    }
}
