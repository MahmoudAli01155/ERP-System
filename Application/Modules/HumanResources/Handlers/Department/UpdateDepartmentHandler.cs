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
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand, bool>
    {
        private readonly IDepartmentService _service;

        public UpdateDepartmentHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _service.UpdateAsync(request.Id, request.Dto);
        }
    }
}
