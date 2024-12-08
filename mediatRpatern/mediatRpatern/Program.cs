using System.ComponentModel;
using mediatRpatern;
using mediatRpatern.Interface;
using mediatRpatern.Interface.Orders;
using Microsoft.Extensions.DependencyInjection;

public class Program
{

    
    public static void Main(string[] args)
    {
        var serviceProvider = Container.ConfigureServices();

        var mediator = serviceProvider.GetService<IMediator>();

        var response = mediator.Send<OrderRequest, OrderResponse>(new OrderRequest { Message = "Process this order" });
        Console.WriteLine($"Response: {response.ResponseMessage}");

        mediator.Publish(new OrderNotification { NotificationMessage = "Order shipped" });
    }
}