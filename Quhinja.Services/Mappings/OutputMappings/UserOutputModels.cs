using AutoMapper;
using Quhinja.Data.Entiities.Enums;
using Quhinja.Data.Entities;
using Quhinja.Services.Models.OutputModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quhinja.Services.Mappings.OutputMappings
{
    public class UserOutputModels : Profile
    {
        public UserOutputModels()
        {
            CreateMap<User, UserInfoOutputModel>()
          .ForMember(user => user.Gender, opt => opt.MapFrom(user => user.Gender == Gender.Female ? "Ženski" : "Muški"))
               .ForMember(user => user.Roles, opt => opt.MapFrom(user =>
                user.UserRoles.Select(x => new string(x.RoleId == 1 ? "admin" : x.RoleId == 2 ? "employee":"unknown"))));
        }
    }
}
