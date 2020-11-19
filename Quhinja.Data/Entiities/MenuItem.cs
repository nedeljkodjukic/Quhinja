using System;
using System.Collections.Generic;

namespace Quhinja.Data.Entiities
{
    public class MenuItem
    {
        public int Id { get; set; }

        public DateTime DateOfDish { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public ICollection<MissedLunch> MissedUsers { get; set; }

    }
}