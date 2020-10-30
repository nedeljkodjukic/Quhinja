using Quhinja.Services.Models.OutputModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.OutputModels.Recipe
{
    public class UsersRatingsForRecipeOutputModel
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public RecipeBasicOutputModel  Recipe {get;set;}

        public int UserId { get; set; }

        public UserInfoOutputModel User { get; set; }

        public int Rating { get; set; }
    }
}
