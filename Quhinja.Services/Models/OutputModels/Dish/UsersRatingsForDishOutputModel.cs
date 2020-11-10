using Quhinja.Services.Models.OutputModels.Dish;
using Quhinja.Services.Models.OutputModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.OutputModels.Recipe
{
    public class UsersRatingsForDishOutputModel
    {
        public int Id { get; set; }

        public int DishId { get; set; }

        public DishBasicOutputModel  Dish {get;set;}

        public int UserId { get; set; }

        public UserInfoOutputModel User { get; set; }

        public int Rating { get; set; }
    }
}
