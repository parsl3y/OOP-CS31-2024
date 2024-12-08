namespace mediatRpatern.Interface;

public interface INotificationHandler<TNotification>
{
    void Handle(TNotification notification);
}