using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.InputModels.User
{
   public  class UserLoginInputModel
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public bool ToRemember { get; set; }
    }
}
