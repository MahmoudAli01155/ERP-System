using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.HumanResources.DTOs.Leave
{
    public class LeaveProfile : Profile
    {
        public LeaveProfile() { 
            CreateMap<Domain.Entities.Leave, CreateLeaveDto>().ReverseMap();
        }
    }
}
