using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Commands.Leave
{
    public record ApproveLeaveCommand(Guid Id) : IRequest<bool>;
}
