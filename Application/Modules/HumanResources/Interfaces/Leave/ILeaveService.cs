using Application.Modules.HumanResources.DTOs.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Interfaces.Leave
{
    public interface ILeaveService
    {
        Task<Guid> CreateAsync(CreateLeaveDto dto);
        Task<bool> ApproveAsync(Guid id);
        Task<bool> RejectAsync(Guid id);
    }
}
