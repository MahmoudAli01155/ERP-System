using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Guid OrderId { get; private set; }
        public Order Order { get; private set; } = null!;

        public decimal Amount { get; private set; }

        public PaymentStatus Status { get; private set; }

        public Payment(Guid orderId, decimal amount)
        {
            OrderId = orderId;
            Amount = amount;
            Status = PaymentStatus.Pending;
        }

        public void MarkSuccess()
        {
            Status = PaymentStatus.Completed;
        }

        public void MarkFailed()
        {
            Status = PaymentStatus.Failed;
        }
    }
}
