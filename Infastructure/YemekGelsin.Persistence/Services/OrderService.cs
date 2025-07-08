using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.DTOs.OrderDtos.RequestDtos;
using YemekGelsin.Application.DTOs.OrderDtos.ResultDtos;
using YemekGelsin.Domain.Entities;
using YemekGelsin.Domain.Enums;
using YemekGelsin.Persistence.Contexts;

namespace YemekGelsin.Persistence.Services;

public class OrderService(YemekGelsinDbContext context) : GenericService<Order>(context), IOrderService
{
    public async Task<CreateOrderResultDto> AddAsync(CreateOrderDto createOrder)
    {
        var order = new Order()
        {
            UserId = createOrder.UserId,
            RestaurantId = createOrder.RestaurantId,
            Status = OrderStatus.SiparisOlusturuldu,
            OrderProducts = new List<OrderProduct>()
        };
        foreach (var item in createOrder.Products)
        {
            order.OrderProducts.Add(new OrderProduct()
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity
            });
        }
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        return new CreateOrderResultDto()
        {
            Successed = true,
            Message = "Siparişiniz Başarıyla Oluşturuldu"
        };
    }
}