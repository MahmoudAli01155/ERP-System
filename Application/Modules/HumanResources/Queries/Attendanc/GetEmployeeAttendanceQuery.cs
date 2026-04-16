using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Attendanc;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Queries.Attendanc
{
    public record GetEmployeeAttendanceQuery(
        Guid EmployeeId,
        int Page,
        int PageSize
    ) : IRequest<PagedResult<AttendanceDto>>;
}
