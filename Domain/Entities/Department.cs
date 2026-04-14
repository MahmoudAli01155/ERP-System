using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Department : BaseEntity
    {
        public string ArName { get; set; } = null!;
        public string EnName { get; set; } = null!;

        // Relations
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
