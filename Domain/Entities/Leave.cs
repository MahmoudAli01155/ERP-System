using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities
{
    public class Leave : BaseEntity
    {
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public LeaveType LeaveType { get; private set; } = LeaveType.Unpaid;
        public LeaveStatus Status { get; private set; } = LeaveStatus.Pending;

        public string Reason { get; private set; } = null!;


        // 🔥 EF Core constructor (IMPORTANT)
        private Leave() { }

        // Business constructor
        public Leave(Guid employeeId, DateTime from, DateTime to, string reason)
        {
            if (to < from)
                throw new Exception("End date cannot be before start date");

            EmployeeId = employeeId;
            StartDate = from.Date;
            EndDate = to.Date;
            Reason = reason;
        }

        public void Approve()
        {
            if (Status != LeaveStatus.Pending)
                throw new Exception("Only pending leaves can be approved");

            Status = LeaveStatus.Approved;
            ModifiedAt = DateTime.UtcNow;
        }

        public void Reject()
        {
            if (Status != LeaveStatus.Pending)
                throw new Exception("Only pending leaves can be rejected");

            Status = LeaveStatus.Rejected;
            ModifiedAt = DateTime.UtcNow;
        }
    }
}