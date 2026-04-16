using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Employee;
using Application.Modules.HumanResources.Interfaces.Employee;
using Application.Modules.HumanResources.Queries.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Handlers.Employee
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, PagedResult<EmployeeDto>>
    {
        private readonly IEmployeeService _service;

        public GetEmployeesHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<PagedResult<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(request);
        }
    }
}
