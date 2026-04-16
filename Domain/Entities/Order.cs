using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public string UserId { get; private set; } = null!;

        public decimal TotalAmount { get; private set; }

        public OrderStatus Status { get; private set; }

        public ICollection<OrderItem> Items { get; private set; }
            = new List<OrderItem>();

        public Order(string userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
        }

        public void AddItem(Guid productId, decimal price, int quantity)
        {
            Items.Add(new OrderItem(productId, price, quantity));
            Recalculate();
        }

        private void Recalculate()
        {
            TotalAmount = Items.Sum(x => x.Price * x.Quantity);
        }

        public void MarkAsPaid()
        {
            Status = OrderStatus.Paid;
        }
    }
}
