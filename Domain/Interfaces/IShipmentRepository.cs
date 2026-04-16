using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IShipmentRepository : IRepository<Shipment>
    {
        Task<IEnumerable<Shipment>> GetByStatusAsync(ShipmentStatus status);

        Task<Shipment?> GetWithOrderAsync(Guid id);
    }
}
