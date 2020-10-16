using System;

namespace Quhinja.Data.Entiities
{
    public class Menu
    {
        public int Id { get; set; }

        public DateTime DateOfDish { get; set; }

        public Recipe Recipe { get; set; }

        //public int RecipeId { get; set; }


    }
}