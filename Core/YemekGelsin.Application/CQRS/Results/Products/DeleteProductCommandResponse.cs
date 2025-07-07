namespace YemekGelsin.Application.CQRS.Results.Products;

public class DeleteProductCommandResponse
{
    public bool Successed { get; set; }
    public string Message { get; set; }
}