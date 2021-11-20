using Condominio.Application.Interfaces.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.IO;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Condominio.Service.EmailService
{
    public class NotificationService : INotificationService
    {
        public void SendEmail(string email, string username)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Renzo Qunhua", "renzors@outlook.com"));
            message.To.Add(new MailboxAddress("Renzo", email));
            message.Subject = "How you doin?";

            var html = File.ReadAllText("D:/Users/renzo/Documents/Development/bodymail.html")
                .Replace("*|NAME|*", username);

            message.Body = new TextPart("html") { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("renzors@outlook.com", "*****"); // insert password
            smtp.Send(message);
            smtp.Disconnect(true);
        }

        public void SendSMS(string mobileNumber)
        {
            TwilioClient.Init("ACCOUNT_SID", "AUTH_TOKEN");

            var message = MessageResource.Create(
                new PhoneNumber("+553499134****"),
                from: new PhoneNumber("+553499134****"),
                body: "Hello World!"
            );
            Console.WriteLine(message.Sid);
        }
    }
}
