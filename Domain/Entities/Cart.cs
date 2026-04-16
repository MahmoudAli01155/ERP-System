using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart : BaseEntity
    {
        public string UserId { get; private set; } = null!;

        public ICollection<CartItem> Items { get; private set; }
            = new List<CartItem>();

        public Cart(string userId)
        {
            UserId = userId;
        }

        public void AddItem(Guid productId, int quantity)
        {
            var existing = Items.FirstOrDefault(x => x.ProductId == productId);

            if (existing != null)
            {
                existing.Increase(quantity);
            }
            else
            {
                Items.Add(new CartItem(productId, quantity));
            }
        }

        public void UpdateItem(Guid productId, int quantity)
        {
            var item = Items.FirstOrDefault(x => x.ProductId == productId);

            if (item == null)
                throw new Exception("Item not found");

            item.Update(quantity);
        }

        public void RemoveItem(Guid productId)
        {
            var item = Items.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
                Items.Remove(item);
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
