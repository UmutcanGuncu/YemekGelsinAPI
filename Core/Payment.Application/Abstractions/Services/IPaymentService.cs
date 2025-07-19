using Order.Application.DTOs.Payments.RequestDtos;
using Order.Application.DTOs.Payments.ResultDtos;

namespace Order.Application.Abstractions.Services;

public interface IPaymentService
{
    Task<PaymentStartResultDto> PaymentStartAsync(PaymentStartDto  paymentStartDto);
}