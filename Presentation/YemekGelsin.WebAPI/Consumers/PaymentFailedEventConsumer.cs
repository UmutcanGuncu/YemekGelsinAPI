using MassTransit;
using Shared.Events;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.DTOs.OrderDtos.RequestDtos;

namespace YemekGelsin.WebAPI.Consumers;

public class PaymentFailedEventConsumer(IOrderService orderService) : IConsumer<PaymentFailedEvent>
{
    public async Task Consume(ConsumeContext<PaymentFailedEvent> context)
    {
        UpdateOrderStatusDto dto = new UpdateOrderStatusDto()
        {
            OrderId = Guid.Parse(context.Message.OrderId),
            PaymentStatus = false
        };
        await orderService.UpdateOrderStatus(dto);
    }
}