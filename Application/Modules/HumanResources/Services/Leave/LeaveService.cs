using Application.Modules.HumanResources.DTOs.Leave;
using Application.Modules.HumanResources.Interfaces.Leave;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Disambiguate the entity type when a namespace named "Leave" exists.
// Adjust the namespace below (Domain.Entities.Leave) if your entity lives elsewhere.
using LeaveEntity = Domain.Entities.Leave;

namespace Application.Modules.HumanResources.Services.Leave
{
    public class LeaveService : ILeaveService
    {
        private readonly IUnitOfWork _uow;

        public LeaveService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Guid> CreateAsync(CreateLeaveDto dto)
        {
            var Leave = await _uow.LeaveRepository.GetByIdAsync(dto.Id);

            if (Leave == null)
                throw new Exception("Invalid LeaveId");

            var leave = new LeaveEntity(dto.Id, dto.StartDate, dto.EndDate, dto.Reason);

            await _uow.LeaveRepository.AddAsync(leave);
            await _uow.SaveChangesAsync();

            return leave.Id;
        }

        public async Task<bool> ApproveAsync(Guid id)
        {
            var leave = await _uow.LeaveRepository.GetByIdAsync(id);

            if (leave == null)
                throw new Exception("Leave not found");

            leave.Approve();

            _uow.LeaveRepository.Update(leave);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RejectAsync(Guid id)
        {
            var leave = await _uow.LeaveRepository.GetByIdAsync(id);

            if (leave == null)
                throw new Exception("Leave not found");

            leave.Reject();

            _uow.LeaveRepository.Update(leave);
            await _uow.SaveChangesAsync();

            return true;
        }
    }
}
