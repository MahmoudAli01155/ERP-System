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
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeeService _service;

        public UpdateEmployeeHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _service.UpdateEmployeeAsync(request.Id, request.Dto);
        }
    }
}
