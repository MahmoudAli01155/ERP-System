using Application.Modules.HumanResources.Commands.Leave;
using Application.Modules.HumanResources.Interfaces.Leave;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Handlers.Leave
{
    public class RejectLeaveHandler : IRequestHandler<RejectLeaveCommand, bool>
    {
        private readonly ILeaveService _service;

        public RejectLeaveHandler(ILeaveService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(RejectLeaveCommand request, CancellationToken cancellationToken)
        {
            return await _service.RejectAsync(request.Id);
        }
    }
}
