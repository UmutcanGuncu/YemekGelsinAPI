namespace YemekGelsin.Application.DTOs.OrderDtos.RequestDtos;

public class UpdateOrderStatusDto
{
    public Guid OrderId { get; set; }
    public bool PaymentStatus { get; set; }
}