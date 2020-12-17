using System.Collections.Generic;

namespace Quhinja.Data.Entiities
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public byte [] Image { get; set; }
        public ICollection<IngridientInRecipe> Ingridients { get; set; }

        public Dish Dish { get; set; }

        public int DishId { get; set; }

        public string WayOfPreparing { get; set; }

        public string Preview { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }

        public string PreparationTime { get; set; }

    }
}