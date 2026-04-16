using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Shipment : BaseEntity
    {
        public Guid OrderId { get; private set; }
        public Guid WarehouseId { get; private set; }

        public string DeliveryAddress { get; private set; } = null!;
        public ShipmentStatus Status { get; private set; } = ShipmentStatus.Pending;


        // 🔥 EF Core constructor (IMPORTANT)
        private Shipment() { }

        // Business constructor
        public Shipment(Guid orderId, Guid warehouseId, string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new Exception("Address required");

            OrderId = orderId;
            WarehouseId = warehouseId;
            DeliveryAddress = address;
        }

        public void Ship()
        {
            if (Status != ShipmentStatus.Pending)
                throw new Exception("Invalid state");

            Status = ShipmentStatus.Shipped;
        }

        public void Deliver()
        {
            if (Status != ShipmentStatus.Shipped)
                throw new Exception("Invalid state");

            Status = ShipmentStatus.Delivered;
        }
    }
}
