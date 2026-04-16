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
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeService _service;

        public DeleteEmployeeHandler(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteEmployeeAsync(request.Id);
        }
    }
}
