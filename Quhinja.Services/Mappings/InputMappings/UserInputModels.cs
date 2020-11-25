using AutoMapper;
using Quhinja.Data.Entiities;
using Quhinja.Data.Entiities.Enums;
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
            CreateMap<UserUpdateInputModel, User>();
            CreateMap<AdminRegistrationInputModel, User>();
            CreateMap<UserRegistrationInputModel, User>()
                .ForMember(user => user.Gender, opt => opt.MapFrom(model => model.IsFemale ? Gender.Female : Gender.Male));
       
        }

    }
}
