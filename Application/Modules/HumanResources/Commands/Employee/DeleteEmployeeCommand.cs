using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Commands.Employee
{
    public record DeleteEmployeeCommand(Guid Id) : IRequest<bool>;
}
