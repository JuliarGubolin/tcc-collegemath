using CollegeMath.Application.Helpers;
using CollegeMath.Application.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace CollegeMath.Application.Applications
{
    public class EmailApplication : IEmailApplication
    {
        private readonly EmailSettings _emailSettings;

        public EmailApplication(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(EmailRequest emailRequest)
        {
            MailMessage message = new MailMessage 
            {
                From = new MailAddress(_emailSettings.Email, _emailSettings.DisplayName),
                Subject = emailRequest.Subject,
            };
            message.To.Add(new MailAddress(emailRequest.ToEmail));

            SmtpClient smtpClient = new SmtpClient();

            ByPassCertificateValidation();

            message.IsBodyHtml = true;
            message.Body = emailRequest.Body;

            smtpClient.Port = _emailSettings.Port;
            smtpClient.Host = _emailSettings.Host;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtpClient.SendMailAsync(message);
        }

        private void ByPassCertificateValidation()
        {
            ServicePointManager.ServerCertificateValidationCallback =
            delegate (
                object s,
                X509Certificate certificate,
                X509Chain chain,
                SslPolicyErrors sslPolicyErrors
            )
            {
                return true;
            };
        }
    }
}