using System.Collections.Generic;

namespace Quhinja.Data.Entiities
{
    public class DishType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}
