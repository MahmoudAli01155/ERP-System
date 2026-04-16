using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Attendanc;
using Application.Modules.HumanResources.Interfaces.Attendanc;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Services.Attendanc
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AttendanceService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Guid> CheckInAsync(CreateAttendanceDto dto)
        {
            var employee = await _uow.EmployeeRepository.GetByIdAsync(dto.EmployeeId);

            if (employee == null)
                throw new Exception("Invalid EmployeeId");

            var today = DateTime.UtcNow.Date;

            var exists = await _uow.AttendanceRepository
                .AnyAsync(x => x.EmployeeId == dto.EmployeeId && x.Date == today);

            if (exists)
                throw new Exception("Already checked in today");

            var attendance = new Attendance(dto.EmployeeId, today);

            attendance.CheckIn(DateTime.UtcNow);

            await _uow.AttendanceRepository.AddAsync(attendance);
            await _uow.SaveChangesAsync();

            return attendance.Id;
        }

        public async Task<bool> CheckOutAsync(Guid attendanceId)
        {
            var attendance = await _uow.AttendanceRepository.GetByIdAsync(attendanceId);

            if (attendance == null)
                throw new Exception("Attendance not found");

            attendance.CheckOut(DateTime.UtcNow);

            _uow.AttendanceRepository.Update(attendance);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async Task<PagedResult<AttendanceDto>> GetEmployeeAttendanceAsync(Guid employeeId, int page, int pageSize)
        {
            var query = _uow.AttendanceRepository.Query()
                .Where(x => x.EmployeeId == employeeId);

            var total = query.Count();

            var data = query
                .OrderByDescending(x => x.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<AttendanceDto>(
                _mapper.Map<List<AttendanceDto>>(data),
                total
            );
        }
    }
}
