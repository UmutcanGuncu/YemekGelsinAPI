using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Orders;
using YemekGelsin.Application.CQRS.Results.Orders;
using YemekGelsin.Application.DTOs.OrderDtos.RequestDtos;

namespace YemekGelsin.Application.CQRS.Handlers.Orders;

public class CreateOrderCommandHandler(IOrderService orderService, IMapper mapper) : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{
    public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var map = mapper.Map<CreateOrderDto>(request);
        var result = await orderService.AddAsync(map);
        return new()
        {
            Successed = result.Successed,
            Message = result.Message,
        };
    }
}