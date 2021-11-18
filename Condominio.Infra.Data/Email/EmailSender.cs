using System.IO;
using Condominio.Application.Interfaces.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Condominio.Infra.Email
{
    public class EmailSender : IEmailService
    {
        public void SimpleMessage()
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Renzo Qunhua", "renzoqunhua@gmail.com"));
            message.To.Add(new MailboxAddress("Renzo", "renzors@gmail.com"));
            message.Subject = "How you doin?";

            var html = File.ReadAllText("D:/Users/renzo/Documents/Development/bodymail.html")
                .Replace("*|NAME|*", "Renzo");

            message.Body = new TextPart("html") { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("renzoqunhua@gmail.com", "*******"); // insert password
            smtp.Send(message);
            smtp.Disconnect(true);
        }
    }
}