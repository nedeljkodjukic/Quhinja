using System;

namespace Quhinja.Data.Entiities
{
    public class MenuItem
    {
        public int Id { get; set; }

        public DateTime DateOfDish { get; set; }

        public Recipe Recipe { get; set; }

    }
}