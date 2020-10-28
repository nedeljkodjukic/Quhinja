using Quhinja.Data.Entiities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.InputModels.User
{
    public class UserBasicInputModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public Gender? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfEmployment { get; set; }

        public string Position { get; set; }


        public IEnumerable<int> UserRoles { get; set; }

        public int FavouriteDishId { get; set; }
    }
}
