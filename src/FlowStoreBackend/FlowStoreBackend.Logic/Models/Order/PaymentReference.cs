namespace FlowStoreBackend.Logic.Models.Order
{
    public record PaymentReference(Guid OrderId, string PaymentUrl);
}
