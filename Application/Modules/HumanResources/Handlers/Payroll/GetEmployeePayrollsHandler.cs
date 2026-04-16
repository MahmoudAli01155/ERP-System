using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Payroll;
using Application.Modules.HumanResources.Interfaces.Payroll;
using Application.Modules.HumanResources.Queries.Payroll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Handlers.Payroll
{
    public class GetEmployeePayrollsHandler
    : IRequestHandler<GetEmployeePayrollsQuery, PagedResult<PayrollDto>>
    {
        private readonly IPayrollService _service;

        public GetEmployeePayrollsHandler(IPayrollService service)
        {
            _service = service;
        }

        public async Task<PagedResult<PayrollDto>> Handle(
            GetEmployeePayrollsQuery request,
            CancellationToken cancellationToken)
        {
            return await _service.GetEmployeePayrollsAsync(
                request.EmployeeId,
                request.Page,
                request.PageSize
            );
        }
    }
}
