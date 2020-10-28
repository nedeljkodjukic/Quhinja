using AutoMapper;
using Quhinja.Data.Entiities;
using Quhinja.Data.Entities;
using Quhinja.Services.Models.InputModels.User;

namespace Quhinja.Services.Mappings.InputMappings
{
    public class UserInputModels :Profile
    {
        public UserInputModels()
        {
            CreateMap<UserBasicInputModel, User>().
                ForMember(u => u.Gender, opt => opt.MapFrom(u => u.Gender));

            CreateMap<UserLoginInputModel, User>();
        }

    }
}
