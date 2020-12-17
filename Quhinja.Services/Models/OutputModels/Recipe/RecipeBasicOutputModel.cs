using Quhinja.Services.Models.OutputModels.Ingridient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.OutputModels.Recipe
{
    public class RecipeBasicOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string WayOfPreparing { get; set; }

        public string Preview { get; set; }

        public string Picture { get; set; }

       public int? AverageRatings { get; set; }

        public IEnumerable<IngridientsInRecipeBasicOutputModel> Ingridients { get; set; }
        public string PreparationTime { get; set; }
        public byte [] Image { get; set; }

    }
}
