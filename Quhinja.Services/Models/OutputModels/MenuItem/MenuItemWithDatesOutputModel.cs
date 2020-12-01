using Quhinja.Services.Models.OutputModels.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.OutputModels.MenuItem
{
   public class MenuItemWithDatesOutputModel
    {
        public int Id { get; set; }

        public DateTime DateOfDish { get; set; }

        public RecipeBasicOutputModel Recipe { get; set; }

    }
}
