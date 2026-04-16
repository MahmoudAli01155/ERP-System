using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Payroll;
using Application.Modules.HumanResources.Interfaces.Payroll;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Disambiguate the entity type when a namespace named "Payroll" exists.
// Adjust the namespace below (Domain.Entities.Payroll) if your entity lives elsewhere.
using PayrollEntity = Domain.Entities.Payroll;


namespace Application.Modules.HumanResources.Services.Payroll
{
    public class PayrollService : IPayrollService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PayrollService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreatePayrollDto dto)
        {
            var employee = await _uow.EmployeeRepository.GetByIdAsync(dto.EmployeeId);

            if (employee == null)
                throw new Exception("Invalid EmployeeId");

            var exists = await _uow.PayrollRepository.AnyAsync(
                x => x.EmployeeId == dto.EmployeeId &&
                     x.Month == dto.Month &&
                     x.Year == dto.Year);

            if (exists)
                throw new Exception("Payroll already exists for this month");

            var payroll = new PayrollEntity(
                dto.EmployeeId,
                dto.Month,
                dto.Year,
                dto.BaseSalary
            );

            await _uow.PayrollRepository.AddAsync(payroll);
            await _uow.SaveChangesAsync();

            return payroll.Id;
        }

        public async Task<bool> AddBonusAsync(Guid payrollId, decimal amount)
        {
            var payroll = await _uow.PayrollRepository.GetByIdAsync(payrollId);

            if (payroll == null)
                throw new Exception("Payroll not found");

            payroll.ApplyBonus(amount);

            _uow.PayrollRepository.Update(payroll);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddDeductionAsync(Guid payrollId, decimal amount)
        {
            var payroll = await _uow.PayrollRepository.GetByIdAsync(payrollId);

            if (payroll == null)
                throw new Exception("Payroll not found");

            payroll.ApplyDeduction(amount);

            _uow.PayrollRepository.Update(payroll);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async Task<PagedResult<PayrollDto>> GetEmployeePayrollsAsync(Guid employeeId, int page, int pageSize)
        {
            var query = _uow.PayrollRepository.Query()
                .Where(x => x.EmployeeId == employeeId);

            var total = query.Count();

            var data = query
                .OrderByDescending(x => x.Year)
                .ThenByDescending(x => x.Month)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<PayrollDto>(
                _mapper.Map<List<PayrollDto>>(data),
                total
            );
        }
    }
}
