using Quhinja.Services.Models.OutputModels.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.OutputModels.Dish
{
   public class DishWithRecipesOutputModel : DishBasicOutputModel
    {
        public IEnumerable<RecipeBasicOutputModel> Recipes { get; set; }

    }
}
