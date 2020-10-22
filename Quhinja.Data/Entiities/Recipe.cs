using Quhinja.Data.Entiities.Enums;
using System;
using System.Collections.Generic;

namespace Quhinja.Data.Entiities
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Ingridient> Ingridients { get; set; }

        public Dish Dish { get; set; }

        public int DishId { get; set; }

        public string Preview { get; set; }

    }
}