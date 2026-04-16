using Application.Modules.HumanResources.DTOs.Leave;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Commands.Leave
{
    public record CreateLeaveCommand(CreateLeaveDto Dto) : IRequest<Guid>;

}
