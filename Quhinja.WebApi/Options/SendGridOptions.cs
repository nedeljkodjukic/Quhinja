using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quhinja.WebApi.Options
{
    public class SendGridOptions
    {
        public string From { get; set; }
        public string FromName { get; set; }
        public string ApiKey { get; set; }
    }
}
