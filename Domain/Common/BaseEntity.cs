using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get;  set; }

        public DateTime? ModifiedAt { get;  set; }
        public string? ModifiedBy { get;  set; }

        public bool IsDeleted { get; protected set; } = false;
        public bool IsActive { get; protected set; } = true;


        public void SoftDelete()
        {
            IsDeleted = true;
            IsActive = false;
            ModifiedAt = DateTime.UtcNow;
            //ModifiedBy = user;
        }
    }
}
