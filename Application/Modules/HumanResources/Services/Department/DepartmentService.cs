using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Department;
using Application.Modules.HumanResources.Interfaces.Department;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentEntity = Domain.Entities.Department;

namespace Application.Modules.HumanResources.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateDepartmentDto dto)
        {
            var entity = new DepartmentEntity(dto.ArName, dto.EnName);

            await _uow.DepartmentRepository.AddAsync(entity);
            await _uow.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateDepartmentDto dto)
        {
            var entity = await _uow.DepartmentRepository.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Department not found");

            entity.Update(dto.ArName, dto.EnName);

            _uow.DepartmentRepository.Update(entity);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _uow.DepartmentRepository.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Department not found");

            entity.ValidateDeletion();
            entity.SoftDelete(); // ممكن تبعت user بعدين

            _uow.DepartmentRepository.Update(entity);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async Task<DepartmentDto> GetByIdAsync(Guid id)
        {
            var entity = await _uow.DepartmentRepository.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Department not found");

            return _mapper.Map<DepartmentDto>(entity);
        }

        public async Task<PagedResult<DepartmentDto>> GetAllAsync(int page, int pageSize)
        {
            var query = _uow.DepartmentRepository.Query();

            var total = query.Count();

            var data = query
                .OrderByDescending(e => e.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<DepartmentDto>(
                _mapper.Map<List<DepartmentDto>>(data),
                total
            );
        }
    }
}
