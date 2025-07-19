using Order.Application.Abstractions.Services;
using Order.Application.DTOs.Payments.RequestDtos;
using Order.Application.DTOs.Payments.ResultDtos;
using Payment.Domain.Enums;
using Payment.Persistence.Contexts;

namespace Payment.Persistence.Services;

public class PaymentService(PaymentDbContext context) : IPaymentService
{
    public async Task<PaymentStartResultDto> PaymentStartAsync(PaymentStartDto paymentStartDto)
    {
        Domain.Entities.Payment payment = new ()
        {
            OrderId = paymentStartDto.OrderId,
            CustomerId = paymentStartDto.CustomerId,
            Description = paymentStartDto.Description,
            TotalPrice = paymentStartDto.TotalPrice,
            PaymentStatus = PaymentStatus.Tamamlandı
        }; 
        await context.Payments.AddAsync(payment);
        Random random = new Random();
        var rndm = random.Next(0, 7);
        if (rndm == 0)
            return new PaymentStartResultDto()
            {
                Success = false,
                Message = "Payment start failed",
                OrderId = payment.OrderId
            };
        
        await context.SaveChangesAsync();
        return new PaymentStartResultDto()
        {
            Success = true,
            Message = "Payment start success",
            OrderId = payment.OrderId,
        };
    }
}