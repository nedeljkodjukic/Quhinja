using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Interfaces
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(string to, string subject, string htmlContent, string from = null, string fromName = null);
    }
}
