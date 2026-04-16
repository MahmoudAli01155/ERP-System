using Application.Modules.HumanResources.Commands.Department;
using Application.Modules.HumanResources.Interfaces.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Handlers.Department
{
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, Guid>
    {
        private readonly IDepartmentService _service;

        public CreateDepartmentHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<Guid> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _service.CreateAsync(request.Dto);
        }
    }
}
