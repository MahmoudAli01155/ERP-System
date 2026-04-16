using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string ArName { get; private set; } = null!;
        public string EnName { get; private set; } = null!;

        public ICollection<Product> Products { get; private set; }
            = new List<Product>();

        public Category(string arName, string enName)
        {
            ArName = arName;
            EnName = enName;
        }

        public void Update(string arName, string enName)
        {
            ArName = arName;
            EnName = enName;

            ModifiedAt = DateTime.UtcNow;
        }
    }
}
