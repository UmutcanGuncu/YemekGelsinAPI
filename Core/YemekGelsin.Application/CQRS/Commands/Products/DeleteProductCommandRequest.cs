using MediatR;
using YemekGelsin.Application.CQRS.Results.Products;

namespace YemekGelsin.Application.CQRS.Commands.Products;

public class DeleteProductCommandRequest(Guid id) : IRequest<DeleteProductCommandResponse>
{
    public Guid Id { get; set; } = id;
}