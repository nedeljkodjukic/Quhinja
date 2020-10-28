using AutoMapper;
using Quhinja.Data.Entiities;
using Quhinja.Services.Models.InputModels.Ingridient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Mappings.InputMappings
{
    public class IngridientInputModels : Profile
    {
        public IngridientInputModels()
        {
            CreateMap<IngridientBasicInputModel, Ingridient>();
            CreateMap<IngridientsInRecipeBasicInputModel, IngridientInRecipe>();

        }
    }
}
