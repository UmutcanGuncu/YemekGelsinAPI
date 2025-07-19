using MassTransit;
using Order.Application.Abstractions.Services;
using Order.Application.DTOs.Payments.RequestDtos;
using Shared;
using Shared.Events;

namespace Payment.WebAPI.Consumers;

public class OrderCreatedEventConsumer(IPaymentService paymentService, ISendEndpointProvider sendEndpointProvider) : IConsumer<OrderCreatedEvent>
{
    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        var result = await paymentService.PaymentStartAsync(new PaymentStartDto()
        {
            CustomerId = context.Message.CustomerId,
            OrderId = context.Message.OrderId,
            TotalPrice = context.Message.TotalPrice,
            Description = context.Message.Description,
        });
        if (result.Success)
        {
            //payment başarılı eventini fırlat 
           var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettings.Order_PaymentSucceededEventQueue}"));
           PaymentSuccessedEvent paymentSuccessedEvent = new PaymentSuccessedEvent()
           {
               OrderId = result.OrderId,
               Message = result.Message
           }; 
           await sendEndpoint.Send(paymentSuccessedEvent);
        }
        else
        {
            var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettings.Order_PaymentFailedEventQueue}"));
            PaymentFailedEvent paymentFailedEvent = new PaymentFailedEvent()
            {
                OrderId = result.OrderId,
                Message = result.Message
            };
            await sendEndpoint.Send(paymentFailedEvent);
        }
    }
    
}