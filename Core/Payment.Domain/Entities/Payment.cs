using Payment.Domain.Entities.Common;
using Payment.Domain.Enums;

namespace Payment.Domain.Entities;

public class Payment : BaseEntity
{
    public string OrderId {get; set;}
    public string CustomerId {get; set;}
    public decimal TotalPrice {get; set;}
    public PaymentStatus PaymentStatus {get; set;}
    public string? Description {get; set;}
}