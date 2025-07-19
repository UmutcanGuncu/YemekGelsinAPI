namespace Shared;

public static class RabbitMQSettings
{
    public const string Payment_OrderCreatedEventQueue = "payment_order_created";
    public const string Order_PaymentSucceededEventQueue = "order_payment_succeeded";
    public const string Order_PaymentFailedEventQueue = "order_payment_failed";
}