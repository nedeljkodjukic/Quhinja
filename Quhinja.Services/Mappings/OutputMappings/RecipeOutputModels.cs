using AutoMapper;
using Quhinja.Data.Entiities;
using Quhinja.Data.Entiities.Quhinja.Data.Entiities;
using Quhinja.Services.Models.OutputModels.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Mappings.OutputMappings
{
    class RecipeOutputModels: Profile
    {
        public RecipeOutputModels()
    {
            CreateMap<Recipe, RecipeBasicOutputModel>();

            CreateMap<Recipe, RecipeWithDishOutputModel>();

          

        }

    }
}
