namespace Condominio.Application.Interfaces.Services
{
    public interface INotificationService
    {
         void SendEmail(string email, string emailPassword);
         void SendSMS(string mobileNumber);
    }
}