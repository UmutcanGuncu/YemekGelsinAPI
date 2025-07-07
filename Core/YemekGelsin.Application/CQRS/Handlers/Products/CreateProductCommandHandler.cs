using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Products;
using YemekGelsin.Application.CQRS.Results.Products;

namespace YemekGelsin.Application.CQRS.Handlers.Products;

public class CreateProductCommandHandler(IProductService productService, IMapper mapper) : IRequestHandler<CreateProductCommandRequest,CreateProductCommandResponse>
{
    public Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}