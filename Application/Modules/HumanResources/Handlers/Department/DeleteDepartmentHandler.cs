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
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        private readonly IDepartmentService _service;

        public DeleteDepartmentHandler(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteAsync(request.Id);
        }
    }
}
