using AutoMapper;
using Quhinja.Data.Entiities;
using Quhinja.Services.Models.OutputModels.DishType;

namespace Quhinja.Services.Mappings.OutputMappings
{
    class DishTypeOutputModels : Profile
    {
        public DishTypeOutputModels()
        {
            CreateMap<DishType, DishTypeBasicOutputModel>();
        }

    }
}
