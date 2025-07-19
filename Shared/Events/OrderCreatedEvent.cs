namespace Shared.Events;

public class OrderCreatedEvent
{
    public string OrderId { get; set; }
    public string CustomerId { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Description{ get; set; }
}