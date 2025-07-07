using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Products;
using YemekGelsin.Application.CQRS.Results.Products;

namespace YemekGelsin.Application.CQRS.Handlers.Products;

public class UpdateProductCommandHandler(IProductService productService, IMapper mapper) : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    public Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}