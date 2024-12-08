using Library.Entities;

namespace Library.Interfaces;

public interface INotificationService
{
    void SendEmail(User user, string message);
}