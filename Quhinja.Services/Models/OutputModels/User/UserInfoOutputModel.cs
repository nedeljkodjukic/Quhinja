using Quhinja.Services.Models.OutputModels.Dish;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.OutputModels.User
{
    public class UserInfoOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DateOfEmployment { get; set; }

        public string Position { get; set; }

        public string ProfilePictureUrl { get; set; }

        public DishBasicOutputModel FavouriteDish { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
