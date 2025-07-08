using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Products;
using YemekGelsin.Application.CQRS.Results.Products;
using YemekGelsin.Domain.Entities;

namespace YemekGelsin.Application.CQRS.Handlers.Products;

public class CreateProductCommandHandler(IProductService productService, IMapper mapper) : IRequestHandler<CreateProductCommandRequest,CreateProductCommandResponse>
{
    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var map = mapper.Map<Product>(request);
        var result = await productService.AddAsync(map);
        string message = result == true ? "Ürün Başarıyla Kayıt Edildi" : "Ürün Kayıt Edilirken Hatayla Karşılaşıldı";
        return new()
        {
            Successed = result,
            Message = message
        };
    }
}