using Application.Modules.HumanResources.Commands.Payroll;
using Application.Modules.HumanResources.Interfaces.Payroll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Handlers.Payroll
{
    public class CreatePayrollHandler : IRequestHandler<CreatePayrollCommand, Guid>
    {
        private readonly IPayrollService _service;

        public CreatePayrollHandler(IPayrollService service)
        {
            _service = service;
        }

        public async Task<Guid> Handle(CreatePayrollCommand request, CancellationToken cancellationToken)
        {
            return await _service.CreateAsync(request.Dto);
        }
    }
}
