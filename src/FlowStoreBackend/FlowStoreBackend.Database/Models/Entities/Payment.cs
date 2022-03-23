using FlowStoreBackend.Database.Models.Enums;
using NodaTime;

namespace FlowStoreBackend.Database.Models.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Instant CreatedAt { get; set; } = SystemClock.Instance.GetCurrentInstant();
        public Instant? PaidAt { get; set; }
        public string YookassaPaymentId { get; set; } = default!;
        public decimal Amount { get; set; }
        public PaymentState State { get; set; }
    }
}
