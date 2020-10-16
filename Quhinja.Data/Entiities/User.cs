using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace Quhinja.Data.Entities
{

    public class User : IdentityUser<int>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public Gender? Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public string ProfilePictureUrl { get; set; }

        public IEnumerable<IdentityUserRole<int>> UserRoles { get; set; }

    }
}