using System;
using System.Collections.Generic;

namespace Quhinja.Services.Models.InputModels.User
{
    public class UserRegistrationInputModel
    {

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsFemale { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfEmployment { get; set; }
        public IEnumerable<int> Roles { get; set; }

        public int? FavouriteDishId { get; set; }

        public string Position { get; set; }

    }
}
