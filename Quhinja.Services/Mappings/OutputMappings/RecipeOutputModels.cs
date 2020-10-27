using AutoMapper;
using Quhinja.Data.Entiities;
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
        CreateMap<Recipe, RecipeBasicOutputModel>().
                ForMember(rr => rr.AverageRatings, opt => opt.MapFrom(r => r.AverageRatings));

            CreateMap<Recipe, RecipeWithDishOutputModel>();

        }

    }
}
