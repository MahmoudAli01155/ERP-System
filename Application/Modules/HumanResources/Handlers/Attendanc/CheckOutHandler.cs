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
    public class CheckOutHandler : IRequestHandler<CheckOutCommand, bool>
    {
        private readonly IAttendanceService _service;

        public CheckOutHandler(IAttendanceService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(CheckOutCommand request, CancellationToken cancellationToken)
        {
            return await _service.CheckOutAsync(request.AttendanceId);
        }
    }
}
