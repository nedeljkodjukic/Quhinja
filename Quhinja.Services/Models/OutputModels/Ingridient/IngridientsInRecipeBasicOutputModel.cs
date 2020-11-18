using Quhinja.Services.Models.OutputModels.Recipe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Quhinja.Services.Models.OutputModels.Ingridient
{
    public class IngridientsInRecipeBasicOutputModel
    {
        public int Id { get; set; }
        public int IngridientId { get; set; }
        
        public IngridientBasicOutputModel Ingridient { get; set; }

        public int RecipeId { get; set; }

        public string Unit { get; set; }

        public int Quantity { get; set; }
       [JsonIgnore]//!!!!!!!
        public RecipeBasicOutputModel Recipe { get; set; }
    }
}
