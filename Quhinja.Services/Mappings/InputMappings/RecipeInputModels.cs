using AutoMapper;
using Quhinja.Data.Entiities;
using Quhinja.Data.Entiities.Quhinja.Data.Entiities;
using Quhinja.Services.Models.InputModels.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Mappings.InputMappings
{
    public class RecipeInputModels : Profile
    {
        public RecipeInputModels()
        {
            CreateMap<RecipeBasicInputModel, Recipe>();

                


            CreateMap<RecipeWithDishInputModel, Recipe>();

        }

    }
}
