using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.DTOs.Attendanc
{
    public class AttendanceDto
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public bool IsAbsent { get; set; }
    }
}
