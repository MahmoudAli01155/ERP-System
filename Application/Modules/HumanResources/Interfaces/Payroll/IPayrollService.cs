using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Interfaces.Payroll
{
    public interface IPayrollService
    {
        Task<Guid> CreateAsync(CreatePayrollDto dto);
        Task<bool> AddBonusAsync(Guid payrollId, decimal amount);
        Task<bool> AddDeductionAsync(Guid payrollId, decimal amount);
        Task<PagedResult<PayrollDto>> GetEmployeePayrollsAsync(Guid employeeId, int page, int pageSize);
    }
}
