using AutoMapper;
using Quhinja.Data.Entiities;
using Quhinja.Data.Entiities.Quhinja.Data.Entiities;
using Quhinja.Services.Models.InputModels.Dish;
using Quhinja.Services.Models.InputModels.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Mappings.InputMappings
{
   public class DishInputModels : Profile
    {
        public DishInputModels()
        {
            CreateMap<DishBasicInputModel, Dish>();
            CreateMap<UsersRatingForDishInputModel, UsersRatingForDish>();
            CreateMap<DishSelectedRecipeInput, Dish>();

        }
    }
}
