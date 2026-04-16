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
    public class AddDeductionHandler : IRequestHandler<AddDeductionCommand, bool>
    {
        private readonly IPayrollService _service;

        public AddDeductionHandler(IPayrollService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(AddDeductionCommand request, CancellationToken cancellationToken)
        {
            return await _service.AddDeductionAsync(request.PayrollId, request.Amount);
        }
    }
}
