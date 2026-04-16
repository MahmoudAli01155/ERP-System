using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Queries.Department
{
    public record GetDepartmentsQuery(
        int Page,
        int PageSize
    ) : IRequest<PagedResult<DepartmentDto>>;
}
