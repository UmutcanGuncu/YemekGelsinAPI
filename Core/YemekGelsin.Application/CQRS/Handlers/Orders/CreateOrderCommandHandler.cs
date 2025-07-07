using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Orders;
using YemekGelsin.Application.CQRS.Results.Orders;

namespace YemekGelsin.Application.CQRS.Handlers.Orders;

public class CreateOrderCommandHandler(IOrderService orderService, IMapper mapper) : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{
    public Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}