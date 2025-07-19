using YemekGelsin.Application.DTOs.OrderDtos.RequestDtos;
using YemekGelsin.Application.DTOs.OrderDtos.ResultDtos;
using YemekGelsin.Domain.Entities;

namespace YemekGelsin.Application.Abstractions.Services;

public interface IOrderService : IGenericService<Order>
{
    Task<CreateOrderResultDto> AddAsync(CreateOrderDto createOrder);
    Task<UpdateOrderStatusResultDto> UpdateOrderStatus(UpdateOrderStatusDto updateOrderStatusDto);
}