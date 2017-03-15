using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IngolStadtNatur.Services.NH.Utilities
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.sparkpostmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials =
                    new NetworkCredential(ConfigurationManager.AppSettings["EmailAccount"],
                        ConfigurationManager.AppSettings["EmailPassword"])
            };

            // You will need an API Key with 'Send via SMTP' permissions.
            // Create one here: https://app.sparkpost.com/account/credentials

            var from = new MailAddress("testing@sparkpostbox.com");

            var to = new MailAddress(message.Destination);
            var mail = new MailMessage(from, to)
            {
                Subject = message.Subject,
                Body = message.Body
            };


            try
            {
                await smtp.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message + " SparkPost probably not configured correctly.");
            }
        }
    }
}
