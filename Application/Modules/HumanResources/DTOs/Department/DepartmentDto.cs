using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.DTOs.Department
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }

        public string ArName { get; set; } = null!;
        public string EnName { get; set; } = null!;
    }
}
