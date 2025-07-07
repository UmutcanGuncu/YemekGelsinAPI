namespace YemekGelsin.Application.CQRS.Results.Orders;

public class DeleteOrderCommandResponse
{
    public bool Successed { get; set; }
    public string Message { get; set; }
}