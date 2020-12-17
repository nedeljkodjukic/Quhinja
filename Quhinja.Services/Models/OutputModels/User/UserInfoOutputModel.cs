using Quhinja.Data.Entiities;
using Quhinja.Services.Models.OutputModels.Dish;
using Quhinja.Services.Models.OutputModels.MenuItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.OutputModels.User
{
    public class UserInfoOutputModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }

        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfEmployment { get; set; }

        public string Position { get; set; }

        public ICollection<MissedLunchBasicOutputModel> MissedDates { get; set; }


        public byte [] Image { get; set; }
        public string ProfilePictureUrl { get; set; }

        public DishBasicOutputModel FavouriteDish { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
