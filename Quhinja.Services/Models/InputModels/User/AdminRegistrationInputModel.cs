using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.InputModels.User
{
    public class AdminRegistrationInputModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
