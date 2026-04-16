using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.DTOs.Payroll
{
    public class PayrollProfile : Profile
    {
        public PayrollProfile()
        {
            CreateMap<Domain.Entities.Payroll, PayrollDto>();
        }
    }
}
