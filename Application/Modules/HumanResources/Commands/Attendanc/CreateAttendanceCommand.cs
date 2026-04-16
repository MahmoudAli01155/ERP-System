using Application.Modules.HumanResources.DTOs.Attendanc;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Commands.Attendanc
{
    public record CreateAttendanceCommand(CreateAttendanceDto Dto) : IRequest<Guid>;

}
