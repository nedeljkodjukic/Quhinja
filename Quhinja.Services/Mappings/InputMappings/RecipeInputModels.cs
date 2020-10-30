using AutoMapper;
using Quhinja.Data.Entiities;
using Quhinja.Data.Entiities.Quhinja.Data.Entiities;
using Quhinja.Services.Models.InputModels.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Mappings.InputMappings
{
    class RecipeInputModels : Profile
    {
        public RecipeInputModels()
        {
            CreateMap<RecipeBasicInputModel, Recipe>();

            CreateMap<UsersRatingForRecipeInputModel, UsersRatingForRecipe>();
                


            CreateMap<RecipeWithDishInputModel, Recipe>();

        }

    }
}
