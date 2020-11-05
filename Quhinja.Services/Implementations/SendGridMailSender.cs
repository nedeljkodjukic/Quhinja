using Quhinja.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Implementations
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly SendGridClient client;
        private readonly string from;
        public readonly string fromName;

        public SendGridEmailSender(string apiKey, string from, string fromName)
        {
            this.client = new SendGridClient(apiKey);
            this.from = from;
            this.fromName = fromName;
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string htmlContent, string from = null, string fromName = null)
        {
            if (string.IsNullOrWhiteSpace(subject) && string.IsNullOrWhiteSpace(htmlContent))
            {
                throw new ArgumentException("Subject and message should be provided.");
            }

            var fromAddress = new EmailAddress(from ?? this.from, fromName ?? this.fromName);
            var toAddress = new EmailAddress(to);

            var message = MailHelper.CreateSingleEmail(fromAddress, toAddress, subject, null, htmlContent);

            try
            {
                var response = await this.client.SendEmailAsync(message);
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(await response.Body.ReadAsStringAsync());

                return response.StatusCode == System.Net.HttpStatusCode.OK;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
