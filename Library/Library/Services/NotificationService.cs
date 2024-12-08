using Library.Entities;
using Library.Interfaces;

namespace Library.Services;

public class NotificationService : INotificationService
{
    public void SendEmail(User user, string message)
    {
        Console.WriteLine($"Email sent to {user.Email}: {message}");
    }
}