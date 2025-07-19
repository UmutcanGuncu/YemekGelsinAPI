namespace Order.Application.DTOs.Payments.ResultDtos;

public class PaymentStartResultDto
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string OrderId { get; set; }
}