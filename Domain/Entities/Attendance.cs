using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Attendance : BaseEntity
    {
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;

        public DateTime Date { get; private set; }

        public DateTime? CheckInTime { get; private set; }
        public DateTime? CheckOutTime { get; private set; }

        public Attendance(Guid employeeId, DateTime date)
        {
            EmployeeId = employeeId;
            Date = date.Date;
        }

        public void CheckIn(DateTime time)
        {
            if (CheckInTime != null)
                throw new Exception("Already checked in");

            CheckInTime = time;
            ModifiedAt = DateTime.UtcNow;
        }

        public void CheckOut(DateTime time)
        {
            if (CheckInTime == null)
                throw new Exception("Check-in required first");

            if (CheckOutTime != null)
                throw new Exception("Already checked out");

            if (time < CheckInTime)
                throw new Exception("Invalid checkout time");

            CheckOutTime = time;
            ModifiedAt = DateTime.UtcNow;
        }
    }
}
