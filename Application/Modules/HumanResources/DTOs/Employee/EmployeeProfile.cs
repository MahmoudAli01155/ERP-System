using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Disambiguate the entity type when a namespace named "Employee" exists.
// Adjust the namespace below (Domain.Entities.Employee) if your entity lives elsewhere.
using EmployeeEntity = Domain.Entities.Employee;

namespace Application.Modules.HumanResources.DTOs.Employee
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeEntity, EmployeeDto>().ReverseMap();
            CreateMap<CreateEmployeeDto, EmployeeEntity>();
            CreateMap<UpdateEmployeeDto, EmployeeEntity>();
        }
    }
}
