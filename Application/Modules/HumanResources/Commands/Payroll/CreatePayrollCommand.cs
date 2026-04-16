using Application.Modules.HumanResources.DTOs.Payroll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Commands.Payroll
{
    public record CreatePayrollCommand(CreatePayrollDto Dto) : IRequest<Guid>;
}
