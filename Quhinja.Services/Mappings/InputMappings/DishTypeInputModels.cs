using AutoMapper;
using Quhinja.Data.Entiities;
using Quhinja.Services.Models.InputModels.DishType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Mappings.InputMappings
{
   public  class DishTypeInputModels : Profile
    {
        public DishTypeInputModels()
        {
            CreateMap<DishTypeBasicInputModel,DishType >();

        }
    }
}
