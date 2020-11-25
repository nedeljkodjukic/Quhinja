using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.InputModels.Dish
{
    public class DishSelectedRecipeInput
    {
        public int Id { get; set; }
        public int selectedRecipeId { get; set; }
    }
}