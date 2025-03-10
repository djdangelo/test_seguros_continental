using MailKit.Net.Smtp;
using MimeKit;

namespace test_seguros_continental.Common.Email
{
    public class EmailService
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("notificacion", "notificaciones.taxi22@gmail.com"));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = body };
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("notificaciones.taxi22@gmail.com", "oeaarpkajyjvtzri");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
