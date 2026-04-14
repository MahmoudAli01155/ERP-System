using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.DTOs
{
    public class CreateEmployeeCommandDTO : IRequest<Guid>
    {
        public required string ArFullName { get; set; }
        public required string EnFullName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required Guid DepartmentId { get; set; }
        public required string Position { get; set; }
        public required decimal Salary { get; set; }
        public required DateTime HireDate { get; set; }
    }
}
