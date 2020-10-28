using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.InputModels.Ingridient
{
    public class IngridientsInRecipeBasicInputModel
    {

        public int  RecipeId { get; set; }

        public IngridientBasicInputModel Ingridient { get; set; }

        public string Quantity { get; set; }

        
    }
}
