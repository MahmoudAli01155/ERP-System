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
    public class CreateLeaveHandler : IRequestHandler<CreateLeaveCommand, Guid>
    {
        private readonly ILeaveService _service;

        public CreateLeaveHandler(ILeaveService service)
        {
            _service = service;
        }

        public async Task<Guid> Handle(CreateLeaveCommand request, CancellationToken cancellationToken)
        {
            return await _service.CreateAsync(request.Dto);
        }
    }
}
