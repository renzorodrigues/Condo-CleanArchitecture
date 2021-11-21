namespace Condominio.Application.Interfaces.Services
{
    public interface INotificationService
    {
         void SendEmail(string email);
         void SendSMS(string mobileNumber);
    }
}