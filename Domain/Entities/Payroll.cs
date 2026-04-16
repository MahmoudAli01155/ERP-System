using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payroll : BaseEntity
    {
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;

        public int Month { get; private set; }
        public int Year { get; private set; }

        public decimal BaseSalary { get; private set; }
        public decimal Bonuses { get; private set; }
        public decimal Deductions { get; private set; }

        public decimal NetSalary { get; private set; }

        public Payroll(Guid employeeId, int month, int year, decimal baseSalary)
        {
            EmployeeId = employeeId;
            Month = month;
            Year = year;
            BaseSalary = baseSalary;
        }

        public void ApplyBonus(decimal amount)
        {
            Bonuses += amount;
            Recalculate();
        }

        public void ApplyDeduction(decimal amount)
        {
            Deductions += amount;
            Recalculate();
        }

        private void Recalculate()
        {
            NetSalary = BaseSalary + Bonuses - Deductions;
        }
    }
}
