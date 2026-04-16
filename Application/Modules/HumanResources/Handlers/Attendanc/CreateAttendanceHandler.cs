using Application.Modules.HumanResources.Commands.Attendanc;
using Application.Modules.HumanResources.Interfaces.Attendanc;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Handlers.Attendanc
{
    public class CreateAttendanceHandler : IRequestHandler<CreateAttendanceCommand, Guid>
    {
        private readonly IAttendanceService _service;

        public CreateAttendanceHandler(IAttendanceService service)
        {
            _service = service;
        }

        public async Task<Guid> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            return await _service.CheckInAsync(request.Dto);
        }
    }
}
