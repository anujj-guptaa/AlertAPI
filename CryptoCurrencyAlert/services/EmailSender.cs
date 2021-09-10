using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencyAlert.services
{

    public class EmailSender : IEmailSender
    {
        private string _host;
        private string _from;
        private string _alias;
        public EmailSender(IConfiguration iConfiguration)
        {
            var smtpSection = iConfiguration.GetSection("SMTP");
            if (smtpSection != null)
            {
                _host = smtpSection.GetSection("Host").Value;
                _from = smtpSection.GetSection("From").Value;
                _alias = smtpSection.GetSection("Alias").Value;
            }
        }
       

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var basicCredential = new NetworkCredential("anuj@saiintellithink.com", "Cdrsde@123");
            try
            { 
                SmtpClient client = new SmtpClient();
                client.Host = "mail.saiintellithink.com";
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential;

                client.Port = 25;
                client.EnableSsl = false;


                using (client)
                {
                    
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(_from,"Sinclus");
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.To.Add(email);
                    mailMessage.Body = message;
                    mailMessage.Subject = subject;
                    mailMessage.IsBodyHtml = true;

                    await client.SendMailAsync(mailMessage);

              //      client.Send(mailMessage);

                }
            }
            catch
            {

                throw;
            }

        }


    }
}