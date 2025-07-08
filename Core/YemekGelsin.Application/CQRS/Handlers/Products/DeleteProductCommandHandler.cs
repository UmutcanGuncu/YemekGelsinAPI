using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Products;
using YemekGelsin.Application.CQRS.Results.Products;

namespace YemekGelsin.Application.CQRS.Handlers.Products;

public class DeleteProductCommandHandler(IProductService productService): IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
{
    public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await productService.RemoveAsync(request.Id);
        string message = result == true ? "Kayıt Başarıyla Silindi" : "Kayıt Silme İşlemi Başarısız Oldu";
        return new()
        {
            Successed = result,
            Message = message
        };
    }
}