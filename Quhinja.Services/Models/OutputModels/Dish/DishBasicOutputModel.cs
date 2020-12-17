using Quhinja.Services.Models.OutputModels.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.OutputModels.Dish
{
    public class DishBasicOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public byte [] Image { get; set; }

        public string Description { get; set; }

        public string DishType { get; set; }

        public int selectedRecipeId { get; set; }



        public float averageRating { get; set; }

        public RecipeBasicOutputModel selectedRecipe { get; set; }
    }
}
