using mediatRpatern.Interface;
using mediatRpatern.Interface.Orders;

public class OrderRequestHandler : IRequestHandler<OrderRequest, OrderResponse>
{
    private readonly IMediator _mediator;

    public OrderRequestHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public OrderResponse Handle(OrderRequest request)
    {
        Console.WriteLine($"Handling OrderRequest: {request.Message}");

        _mediator.Publish(new OrderNotification { NotificationMessage = "Order processed" });

        return new OrderResponse { ResponseMessage = "Order processed successfully" };
    }
}