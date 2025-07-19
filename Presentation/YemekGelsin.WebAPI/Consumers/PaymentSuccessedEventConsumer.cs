using MassTransit;
using Shared.Events;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.DTOs.OrderDtos.RequestDtos;

namespace YemekGelsin.WebAPI.Consumers;

public class PaymentSuccessedEventConsumer(IOrderService orderService) : IConsumer<PaymentSuccessedEvent>
{
    public async Task Consume(ConsumeContext<PaymentSuccessedEvent> context)
    {
        UpdateOrderStatusDto dto = new UpdateOrderStatusDto()
        {
            OrderId = Guid.Parse(context.Message.OrderId),
            PaymentStatus = true
        };
        await orderService.UpdateOrderStatus(dto);
    }
}