using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Department;
using Application.Modules.HumanResources.Interfaces.Department;
using Application.Modules.HumanResources.Queries.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Handlers.Department
{
    public class GetDepartmentsHandler : IRequestHandler<GetDepartmentsQuery, PagedResult<DepartmentDto>>
    {
        private readonly IDepartmentService _service;

        public GetDepartmentsHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<PagedResult<DepartmentDto>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(request.Page, request.PageSize);
        }
    }
}
