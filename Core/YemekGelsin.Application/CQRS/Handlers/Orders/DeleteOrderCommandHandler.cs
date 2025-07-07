using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Orders;
using YemekGelsin.Application.CQRS.Results.Orders;

namespace YemekGelsin.Application.CQRS.Handlers.Orders;

public class DeleteOrderCommandHandler(IOrderService service) : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
{
    public Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}