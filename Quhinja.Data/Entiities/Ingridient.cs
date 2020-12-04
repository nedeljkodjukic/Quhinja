using System.Collections.Generic;

namespace Quhinja.Data.Entiities
{
    public class Ingridient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<IngridientInRecipe> Recipes { get; set; }

    }
}