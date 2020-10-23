using AutoMapper;
using Quhinja.Data.Entiities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Mappings.OutputMappings
{
    class DishTypeOutputBasicModels : Profile
    {
        public DishTypeOutputBasicModels ()
        {
            CreateMap<DishType, DishTypeOutputBasicModels>();
        }

    }
}
