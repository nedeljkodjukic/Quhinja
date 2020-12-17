using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.OutputModels
{
    public class TokenOutputModel
    {
        public string AccessToken { get; set; }
        public DateTime Expires { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProfilePictureUrl { get; set; }

        public byte [] Image { get; set; }
    }
}
