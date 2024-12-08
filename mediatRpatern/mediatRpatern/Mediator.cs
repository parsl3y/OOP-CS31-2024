using mediatRpatern.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace mediatRpatern;

public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TResponse Send<TRequest, TResponse>(TRequest request)
    {
        var handler = _serviceProvider.GetService<IRequestHandler<TRequest, TResponse>>();
        if (handler == null)
            throw new InvalidOperationException($"Handler for {typeof(TRequest).Name} not registered");

        return handler.Handle(request);
    }

    public void Publish<TNotification>(TNotification notification)
    {
        var handlers = _serviceProvider.GetServices<INotificationHandler<TNotification>>();
        foreach (var handler in handlers)
        {
            handler.Handle(notification);
        }
    }
}

