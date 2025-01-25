using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public class EmailService
    {
        private readonly string _smtpServer = "smtp.example.com";
        private readonly string _smtpUser = "user@example.com";
        private readonly string _smtpPassword = "password";

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            using (var client = new SmtpClient(_smtpServer))
            {
                client.Credentials = new NetworkCredential(_smtpUser, _smtpPassword);
                client.Port = 587;
                client.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpUser),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
