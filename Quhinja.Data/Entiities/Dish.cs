using System.Collections;
using System.Collections.Generic;

namespace Quhinja.Data.Entiities
{
    public class Dish
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public ICollection<Recipe> Recipes { get; set; }

        public int DishTypeId { get; set; }
        public DishType DishType { get; set; }




    }
}