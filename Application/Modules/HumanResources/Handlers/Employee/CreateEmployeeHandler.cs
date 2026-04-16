using Application.Modules.HumanResources.Commands.Employee;
using Application.Modules.HumanResources.Interfaces.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Handlers.Employee
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IEmployeeService _service;

        public CreateEmployeeHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _service.CreateEmployeeAsync(request.Dto);
        }
    }
}
