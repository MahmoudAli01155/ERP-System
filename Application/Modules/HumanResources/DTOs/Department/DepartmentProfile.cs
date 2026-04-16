
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Disambiguate the entity type when a namespace named "Department" exists.
// Adjust the namespace below (Domain.Entities.Department) if your entity lives elsewhere.
using DepartmentEntity = Domain.Entities.Department;

namespace Application.Modules.HumanResources.DTOs.Department
{
    internal class DepartmentProfile :Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentEntity, DepartmentDto>().ReverseMap();
            CreateMap<CreateDepartmentDto, DepartmentEntity>();
            CreateMap<UpdateDepartmentDto, DepartmentEntity>();
        }
    }
}
