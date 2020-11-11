using Quhinja.Services.Models.InputModels.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.InputModels.Dish
{
    public class DishBasicInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }



        public string DishType { get; set; }

    }
}
