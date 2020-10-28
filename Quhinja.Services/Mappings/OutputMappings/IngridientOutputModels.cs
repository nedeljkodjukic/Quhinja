using AutoMapper;
using Quhinja.Data.Entiities;
using Quhinja.Services.Models.OutputModels.Ingridient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Mappings.OutputMappings
{
    class IngridientOutputModels : Profile
    {
        public IngridientOutputModels()
        {
            CreateMap<Ingridient, IngridientBasicOutputModel>();

            CreateMap<IngridientInRecipe, IngridientsInRecipeBasicOutputModel>();
        }

    }
}
