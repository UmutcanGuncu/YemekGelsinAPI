using MediatR;
using YemekGelsin.Application.CQRS.Results.Orders;

namespace YemekGelsin.Application.CQRS.Commands.Orders;

public class DeleteOrderCommandRequest : IRequest<DeleteOrderCommandResponse>
{
    
}