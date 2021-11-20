namespace Condominio.Application.Interfaces.Services
{
    public interface INotificationService
    {
         void SendEmail(string email, string username);
         void SendSMS(string mobileNumber);
    }
}