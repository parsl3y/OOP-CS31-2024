using mediatRpatern;
using mediatRpatern.Interface;
using mediatRpatern.Interface.Orders;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Test;

    public class Test
    {
        [Fact]
        public void Send_ShouldInvokeCorrectHandler()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var mockRequestHandler = new Mock<IRequestHandler<OrderRequest, OrderResponse>>();
            var orderRequest = new OrderRequest { Message = "Test order" };

            mockRequestHandler.Setup(x => x.Handle(It.IsAny<OrderRequest>()))
                .Returns(new OrderResponse { ResponseMessage = "Order processed successfully" });

            mockMediator.Setup(m => m.Send<OrderRequest, OrderResponse>(It.IsAny<OrderRequest>()))
                .Returns(new OrderResponse { ResponseMessage = "Order processed successfully" });

            // Act
            var response = mockMediator.Object.Send<OrderRequest, OrderResponse>(orderRequest);

            // Assert
            Assert.Equal("Order processed successfully", response.ResponseMessage);
            mockMediator.Verify(m => m.Send<OrderRequest, OrderResponse>(It.IsAny<OrderRequest>()), Times.Once);
        }

        [Fact]
        public void Publish_ShouldInvokeNotificationHandler()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var mockNotificationHandler = new Mock<INotificationHandler<OrderNotification>>();
            var orderNotification = new OrderNotification { NotificationMessage = "Order processed" };

            mockNotificationHandler.Setup(x => x.Handle(It.IsAny<OrderNotification>()))
                .Callback<OrderNotification>(n => Assert.Equal("Order processed", n.NotificationMessage));

            mockMediator.Setup(m => m.Publish(It.IsAny<OrderNotification>()));

            // Act
            mockMediator.Object.Publish(orderNotification);

            // Assert
            mockMediator.Verify(m => m.Publish(It.IsAny<OrderNotification>()), Times.Once);
            mockNotificationHandler.Verify(n => n.Handle(It.IsAny<OrderNotification>()), Times.Once);
        }

        [Fact]
        public void Mediator_ShouldReturnCorrectResponseFromHandler()
        {
            // Arrange
            var mockServiceProvider = new Mock<IServiceProvider>();
            var mockRequestHandler = new Mock<IRequestHandler<OrderRequest, OrderResponse>>();

            mockRequestHandler.Setup(handler => handler.Handle(It.IsAny<OrderRequest>()))
                .Returns(new OrderResponse { ResponseMessage = "Order processed successfully" });

            mockServiceProvider.Setup(sp => sp.GetService(typeof(IRequestHandler<OrderRequest, OrderResponse>)))
                .Returns(mockRequestHandler.Object);

            var mediator = new Mediator(mockServiceProvider.Object);

            var orderRequest = new OrderRequest { Message = "Process this order" };

            // Act
            var response = mediator.Send<OrderRequest, OrderResponse>(orderRequest);

            // Assert
            Assert.Equal("Order processed successfully", response.ResponseMessage);
            mockRequestHandler.Verify(handler => handler.Handle(It.IsAny<OrderRequest>()), Times.Once);
        }

        [Fact]
        public void Mediator_ShouldRouteNotificationCorrectly()
        {
            // Arrange
            var mockServiceProvider = new Mock<IServiceProvider>();
            var mockNotificationHandler = new Mock<INotificationHandler<OrderNotification>>();

            mockNotificationHandler.Setup(handler => handler.Handle(It.IsAny<OrderNotification>()))
                .Callback<OrderNotification>(notification => Assert.Equal("Order shipped", notification.NotificationMessage));

            mockServiceProvider.Setup(sp => sp.GetServices(typeof(INotificationHandler<OrderNotification>)))
                .Returns(new[] { mockNotificationHandler.Object });

            var mediator = new Mediator(mockServiceProvider.Object);
            var orderNotification = new OrderNotification { NotificationMessage = "Order shipped" };

            // Act
            mediator.Publish(orderNotification);

            // Assert
            mockNotificationHandler.Verify(handler => handler.Handle(It.IsAny<OrderNotification>()), Times.Once);
        }
    }

