using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Employee;
using Application.Modules.HumanResources.Queries.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Interfaces.Employee
{
    public interface IEmployeeService
    {
        Task<Guid> CreateEmployeeAsync(CreateEmployeeDto dto);
        Task<bool> UpdateEmployeeAsync(Guid id, UpdateEmployeeDto dto);
        Task<bool> DeleteEmployeeAsync(Guid id);
        Task<EmployeeDto> GetByIdAsync(Guid id);
        Task<PagedResult<EmployeeDto>> GetAllAsync(GetEmployeesQuery query);
    }
}
