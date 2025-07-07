using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Orders;
using YemekGelsin.Application.CQRS.Results.Orders;

namespace YemekGelsin.Application.CQRS.Handlers.Orders;

public class UpdateOrderCommandHandler(IOrderService service, IMapper mapper) : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
{
    public Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}