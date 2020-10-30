using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.InputModels.Recipe
{
     public class UsersRatingForRecipeInputModel
    {
        public int RecipeId { get; set; }

        public int UserId { get; set; }

        public int Rating { get; set; }
    }
}
