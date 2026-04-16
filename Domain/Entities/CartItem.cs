using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem
    {
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        public CartItem(Guid productId, int quantity)
        {
            if (quantity <= 0)
                throw new Exception("Invalid quantity");

            ProductId = productId;
            Quantity = quantity;
        }

        public void Increase(int qty)
        {
            Quantity += qty;
        }

        public void Update(int qty)
        {
            if (qty <= 0)
                throw new Exception("Invalid quantity");

            Quantity = qty;
        }
    }
}
