using Quhinja.Services.Models.OutputModels.Dish;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.OutputModels.Recipe
{
   public  class RecipeWithDishOutputModel : RecipeBasicOutputModel
    {
        public DishBasicOutputModel Dish { get; set; }
    }
}
