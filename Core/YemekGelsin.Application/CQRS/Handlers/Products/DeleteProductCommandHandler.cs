using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Products;
using YemekGelsin.Application.CQRS.Results.Products;

namespace YemekGelsin.Application.CQRS.Handlers.Products;

public class DeleteProductCommandHandler(IProductService productService): IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
{
    public Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}