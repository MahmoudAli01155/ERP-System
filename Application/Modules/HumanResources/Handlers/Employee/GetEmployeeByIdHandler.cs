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
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IEmployeeService _service;

        public GetEmployeeByIdHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.Id);
        }
    }
}
