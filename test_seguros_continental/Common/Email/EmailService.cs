using MailKit.Net.Smtp;
using MimeKit;

namespace test_seguros_continental.Common.Email
{
    public class EmailService
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Tu Nombre", "tu-email@dominio.com"));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = body };
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("tu-email@dominio.com", "tu-contraseña");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
