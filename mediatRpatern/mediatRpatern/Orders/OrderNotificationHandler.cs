namespace mediatRpatern.Interface.Orders;

public class OrderNotificationHandler : INotificationHandler<OrderNotification>
{
    public void Handle(OrderNotification notification)
    {
        Console.WriteLine($"Handling Notification: {notification.NotificationMessage}");
    }
}