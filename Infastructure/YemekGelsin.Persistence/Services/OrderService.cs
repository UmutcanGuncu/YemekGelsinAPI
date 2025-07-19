using MassTransit;
using Shared.Events;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.DTOs.OrderDtos.RequestDtos;
using YemekGelsin.Application.DTOs.OrderDtos.ResultDtos;
using YemekGelsin.Domain.Entities;
using YemekGelsin.Domain.Enums;
using YemekGelsin.Persistence.Contexts;

namespace YemekGelsin.Persistence.Services;

public class OrderService(YemekGelsinDbContext context,IPublishEndpoint  publishEndpoint) : GenericService<Order>(context), IOrderService
{
    public async Task<CreateOrderResultDto> AddAsync(CreateOrderDto createOrder)
    {
        decimal price = 0;
        var order = new Order()
        {
            UserId = createOrder.UserId,
            RestaurantId = createOrder.RestaurantId,
            Status = OrderStatus.OdemeBekleniyor,
            OrderProducts = new List<OrderProduct>()
        };
        foreach (var item in createOrder.Products)
        {
            var product = await context.Products.FindAsync(item.ProductId);
            if(product == null)
                return new ()
                {
                    Successed = false,
                    Message = "Ürün Veri Tabanında Bulunamamıştır"
                };
            price = product.Price * item.Quantity;
            order.OrderProducts.Add(new OrderProduct()
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity
            });
        }
        order.TotalPrice = price;
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        OrderCreatedEvent orderCreatedEvent = new OrderCreatedEvent()
        {
            CustomerId = createOrder.UserId.ToString(),
            TotalPrice = price,
            OrderId = order.Id.ToString(),
            Description = "Ödeme Onayı Bekleniyor"
            
        };
        await publishEndpoint.Publish(orderCreatedEvent); 
        return new CreateOrderResultDto()
        {
            Successed = true,
            Message = "Ödeme Onayı Bekleniyor"
        };
    }

    public async Task<UpdateOrderStatusResultDto> UpdateOrderStatus(UpdateOrderStatusDto updateOrderStatusDto)
    {
        var order = await context.Orders.FindAsync(updateOrderStatusDto.OrderId);
        if (order == null)
        {
            return new ()
            {
                Success = false,
                Message = "Sipariş Bilgisi Bulunamadı"
            };
        }
        if (updateOrderStatusDto.PaymentStatus == true)
        {

            order.Status = OrderStatus.SiparisOlusturuldu;
            context.Update(order);
            await context.SaveChangesAsync();
            return new()
            {
                Success = true,
                Message = "Sipariş Başarıyla Ödeme Alındı Olarak Güncellendi"
            };
        }
        order.Status = OrderStatus.İptalEdildi;
        context.Update(order);
        await context.SaveChangesAsync();
        return new()
        {
            Success = false,
            Message = "Siparişiniz Ödeme Gerçekleşmediği İçin İptal Edilmiştir"
        };
        
    }
}