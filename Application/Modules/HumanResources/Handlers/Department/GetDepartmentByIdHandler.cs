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
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {
        private readonly IDepartmentService _service;

        public GetDepartmentByIdHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.Id);
        }
    }
}
