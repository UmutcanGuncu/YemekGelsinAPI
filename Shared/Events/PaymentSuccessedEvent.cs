namespace Shared.Events;

public class PaymentSuccessedEvent
{
    public string OrderId {get; set;}
    public string Message {get; set;}
    
}