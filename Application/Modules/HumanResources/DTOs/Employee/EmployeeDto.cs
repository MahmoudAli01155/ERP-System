using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.DTOs.Employee
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string ArFullName { get; set; }
        public string EnFullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string Status { get; set; }
        public DateTime HireDate { get; set; }
    }
}
