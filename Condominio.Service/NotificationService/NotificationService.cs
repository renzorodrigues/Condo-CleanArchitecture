using Condominio.Application.Interfaces.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.IO;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Condominio.Service.EmailService
{
    public class NotificationService : INotificationService
    {
        public void SendEmail(string email, string emailPassword)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Renzo Qunhua", "renzors@outlook.com"));
            message.To.Add(new MailboxAddress("Renzo", email));
            message.Subject = "Confirmação de cadastro";

            var html = File.ReadAllText("D:/Users/renzo/Documents/Development/bodymail.html")
                .Replace("*|EMAIL|*", email);

            message.Body = new TextPart("html") { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("renzors@outlook.com", emailPassword);
            smtp.Send(message);
            smtp.Disconnect(true);
        }

        public void SendSMS(string mobileNumber)
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "***";
            string authToken = "***";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hi there",
                from: new Twilio.Types.PhoneNumber("+18107886902"),
                to: new Twilio.Types.PhoneNumber("+5534991346615")
            );

            Console.WriteLine(message.Sid);
        }
    }
}
