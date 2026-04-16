using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.DTOs.Payroll
{
    public class CreatePayrollDto
    {
        public Guid EmployeeId { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }

        public decimal BaseSalary { get; set; }
    }
}
