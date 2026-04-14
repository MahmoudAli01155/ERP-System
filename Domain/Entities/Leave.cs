using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Leave : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public LeaveType LeaveType { get; set; }
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;

        public string Reason { get; set; } = null!;
    }
}
