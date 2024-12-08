namespace mediatRpatern.Interface;

public interface IPublisher
{
    void Publish<TNotification>(TNotification notification);
}
