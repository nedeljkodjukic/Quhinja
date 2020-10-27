using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.InputModels.Recipe
{
    public class RecipeWithDishInputModel :RecipeBasicInputModel
    {
        public int DishId { get; set; }
    }
}
