using MediatR;
using YemekGelsin.Application.CQRS.Results.Products;

namespace YemekGelsin.Application.CQRS.Commands.Products;

public class UpdateProductCommandRequest :  IRequest<UpdateProductCommandResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public bool IsActive { get; set; }
    public Guid RestaurantId { get; set; }
}
