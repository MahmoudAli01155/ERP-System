using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Attendanc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Interfaces.Attendanc
{
    public interface IAttendanceService
    {
        Task<Guid> CheckInAsync(CreateAttendanceDto dto);
        Task<bool> CheckOutAsync(Guid attendanceId);
        Task<PagedResult<AttendanceDto>> GetEmployeeAttendanceAsync(Guid employeeId, int page, int pageSize);
    }
}
