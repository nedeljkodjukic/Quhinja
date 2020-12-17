using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;
using Quhinja.Data.Entiities.Enums;
using Quhinja.Data.Entiities;
using Quhinja.Data.Entiities.Quhinja.Data.Entiities;

namespace Quhinja.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public Gender? Gender { get; set; }

        public ICollection<UsersRatingForDish> RatingsInDishes { get; set; }

        public ICollection<MissedLunch> MissedDates { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfEmployment { get; set; }

        public string Position { get; set; }

        public string ProfilePictureUrl { get; set; }

        public IEnumerable<IdentityUserRole<int>> UserRoles { get; set; }

        public Dish FavouriteDish { get; set; }

        public int? FavouriteDishId { get; set; }

        public byte [] Image { get; set; }

    }
}