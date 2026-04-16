using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Employee;
using Application.Modules.HumanResources.Interfaces.Employee;
using Application.Modules.HumanResources.Queries.Employee;
using AutoMapper;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

// Disambiguate the entity type when a namespace named "Employee" exists.
// Adjust the namespace below (Domain.Entities.Employee) if your entity lives elsewhere.
using EmployeeEntity = Domain.Entities.Employee;

namespace Application.Modules.HumanResources.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Guid> CreateEmployeeAsync(CreateEmployeeDto dto)
        {
            var exists = await _uow.EmployeeRepository
                .AnyAsync(e => e.Email == dto.Email);

            if (exists)
                throw new Exception("Email already exists");

            var employee = _mapper.Map<EmployeeEntity>(dto);

            employee.HireDate = DateTime.UtcNow;
            employee.Status = EmployeeStatus.Active;
            await _uow.EmployeeRepository.AddAsync(employee);
            await _uow.SaveChangesAsync();

            return employee.Id;
        }

        public async Task<bool> UpdateEmployeeAsync(Guid id, UpdateEmployeeDto dto)
        {
            var employee = await _uow.EmployeeRepository.GetByIdAsync(id);

            if (employee == null)
                throw new Exception("Employee not found");

            employee.ArFullName = dto.ArFullName;
            employee.EnFullName = dto.EnFullName;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.DepartmentId = dto.DepartmentId;
            employee.Position = dto.Position;
            employee.Salary = dto.Salary;

            _uow.EmployeeRepository.Update(employee);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _uow.EmployeeRepository.GetByIdAsync(id);

            if (employee == null)
                throw new Exception("Employee not found");

            employee.Status = EmployeeStatus.Inactive;

            _uow.EmployeeRepository.Update(employee);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            var employee = await _uow.EmployeeRepository.GetByIdAsync(id);

            if (employee == null)
                throw new Exception("Employee not found");

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<PagedResult<EmployeeDto>> GetAllAsync(GetEmployeesQuery request)
        {
            var query = _uow.EmployeeRepository.Query();

            if (request.DepartmentId.HasValue)
                query = query.Where(e => e.DepartmentId == request.DepartmentId);

            if (!string.IsNullOrEmpty(request.Status))
            {
                if (Enum.TryParse<EmployeeStatus>(request.Status, true, out var statusEnum))
                {
                    query = query.Where(e => e.Status == statusEnum);
                }
            }

            var total = query.Count();

            var data = query
                .OrderByDescending(e => e.HireDate)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            return new PagedResult<EmployeeDto>(
                _mapper.Map<List<EmployeeDto>>(data),
                total);
        }
    }
}
