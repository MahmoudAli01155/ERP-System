using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Attendanc;
using Application.Modules.HumanResources.Interfaces.Attendanc;
using Application.Modules.HumanResources.Queries.Attendanc;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Handlers.Attendanc
{
    public class GetEmployeeAttendanceHandler
    : IRequestHandler<GetEmployeeAttendanceQuery, PagedResult<AttendanceDto>>
    {
        private readonly IAttendanceService _service;

        public GetEmployeeAttendanceHandler(IAttendanceService service)
        {
            _service = service;
        }

        public async Task<PagedResult<AttendanceDto>> Handle(
            GetEmployeeAttendanceQuery request,
            CancellationToken cancellationToken)
        {
            return await _service.GetEmployeeAttendanceAsync(
                request.EmployeeId,
                request.Page,
                request.PageSize
            );
        }
    }
}
