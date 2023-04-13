using EtwLogin.Models;
using EtwLogin.Settings;
using Microsoft.Extensions.Options;
using MimeKit;
using System.IO;
using System.Net.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Threading.Tasks;

namespace EtwLogin.Repository
{
    public class MailService:IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public void  SendEmailAsync(string mailRequest1)
        {
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = mailRequest1;
            var email = new MimeMessage();

            email.Sender = MailboxAddress.Parse(_mailSettings.FromMail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = _mailSettings.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = _mailSettings.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.FromMail, _mailSettings.Password);
             smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
