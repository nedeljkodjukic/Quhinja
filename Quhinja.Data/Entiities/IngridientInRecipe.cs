﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Data.Entiities
{
   public  class IngridientInRecipe
    {

        public int Id { get; set; }
        public int IngridientId { get; set; }
        public Ingridient Ingridient { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public string Quantity { get; set; }
    }
}
