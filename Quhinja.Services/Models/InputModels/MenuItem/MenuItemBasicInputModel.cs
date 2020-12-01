using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.InputModels.MenuItem
{
  public  class MenuItemBasicInputModel
    {
        public int Id { get; set; }

        public DateTime DateOfDish { get; set; }

        public int RecipeId { get; set; }

      
    }
}
