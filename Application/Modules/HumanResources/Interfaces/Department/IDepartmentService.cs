using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Interfaces.Department
{
    public interface IDepartmentService
    {
        Task<Guid> CreateAsync(CreateDepartmentDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateDepartmentDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<DepartmentDto> GetByIdAsync(Guid id);
        Task<PagedResult<DepartmentDto>> GetAllAsync(int page, int pageSize);
    }
}
