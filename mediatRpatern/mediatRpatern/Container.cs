using mediatRpatern;
using mediatRpatern.Interface;
using mediatRpatern.Interface.Orders;
using Microsoft.Extensions.DependencyInjection;

public static class Container
{
    public static IServiceProvider ConfigureServices()
    {
        return new ServiceCollection()
            .AddTransient<IMediator, Mediator>()
            .AddTransient<ISender, Mediator>()
            .AddTransient<IPublisher, Mediator>()
            .AddTransient<IRequestHandler<OrderRequest, OrderResponse>, OrderRequestHandler>()
            .AddTransient<INotificationHandler<OrderNotification>, OrderNotificationHandler>()
            .BuildServiceProvider();
    }
}