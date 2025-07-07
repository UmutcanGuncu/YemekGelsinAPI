namespace YemekGelsin.Application.CQRS.Results.Orders;

public class UpdateOrderCommandResponse
{
    public bool Successed { get; set; }
    public string Message { get; set; }
}