using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Payroll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.Queries.Payroll
{
    public record GetEmployeePayrollsQuery(
        Guid EmployeeId,
        int Page,
        int PageSize
    ) : IRequest<PagedResult<PayrollDto>>;
}
