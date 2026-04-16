using System;
using MediatR;
using Application.Common.Paginations;
using Application.Modules.HumanResources.DTOs.Employee;

namespace Application.Modules.HumanResources.Queries.Employee
{
    public record GetEmployeesQuery : MediatR.IRequest<PagedResult<EmployeeDto>>, IBaseRequest, IEquatable<GetEmployeesQuery>
    {
        public int Page { get; init; }
        public int PageSize { get; init; }
        public Guid? DepartmentId { get; init; }
        public string? Status { get; init; }
    }
}
