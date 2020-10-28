using Quhinja.Data.Entiities.Enums;
using System;
using System.Collections.Generic;

namespace Quhinja.Data.Entiities
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }//sa vise slika????

        public ICollection<IngridientInRecipe> Ingridients { get; set; }

        public Dish Dish { get; set; }

        public int DishId { get; set; }

        public string WayOfPreparing { get; set; }

        public string Preview { get; set; }

        public int? AverageRatings { get; set; }
         //dodaj tabelu vise prema vise ocena
        public int? NumberOfVoters { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }

        public string PreparationTime { get; set; }

    }
}