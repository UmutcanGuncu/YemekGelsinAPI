using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Products;
using YemekGelsin.Application.CQRS.Results.Products;
using YemekGelsin.Domain.Entities;

namespace YemekGelsin.Application.CQRS.Handlers.Products;

public class UpdateProductCommandHandler(IProductService productService, IMapper mapper) : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var map = mapper.Map<Product>(request);
        var result =  await productService.UpdateAsync(map);
        string message = result == true ? "Ürün Güncellendi" : "Ürün not Güncellenemedi";
        return new()
        {
            Successed = result,
            Message = message
        };
    }
}