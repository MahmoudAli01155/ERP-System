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
    public class AddBonusHandler : IRequestHandler<AddBonusCommand, bool>
    {
        private readonly IPayrollService _service;

        public AddBonusHandler(IPayrollService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(AddBonusCommand request, CancellationToken cancellationToken)
        {
            return await _service.AddBonusAsync(request.PayrollId, request.Amount);
        }
    }
}
