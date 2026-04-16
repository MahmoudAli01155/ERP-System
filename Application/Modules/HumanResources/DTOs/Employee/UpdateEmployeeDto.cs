using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.DTOs.Employee
{
    public class UpdateEmployeeDto
    {
        public string ArFullName { get; set; }
        public string EnFullName { get; set; }
        public string PhoneNumber { get; set; }
        public Guid DepartmentId { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
    }
}
