using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.InputModels.User
{
     public class UserUpdateInputModel
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Surname { get; set; }

        public int FavouriteDishId { get; set; }
    }
}
