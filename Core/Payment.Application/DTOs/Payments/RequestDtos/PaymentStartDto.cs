namespace Order.Application.DTOs.Payments.RequestDtos;

public class PaymentStartDto
{
    public string OrderId {get; set;}
    public string CustomerId {get; set;}
    public decimal TotalPrice {get; set;}
    public string? Description {get; set;}
}