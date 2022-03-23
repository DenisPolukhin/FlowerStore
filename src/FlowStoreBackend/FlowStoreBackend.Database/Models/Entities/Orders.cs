using FlowStoreBackend.Database.Models.Enums;
using NodaTime;

namespace FlowStoreBackend.Database.Models.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Instant CreatedAt { get; set; } = SystemClock.Instance.GetCurrentInstant();
        public Instant? PaidAt { get; set; }
        public bool IsDilevery { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public PaymentState State { get; set; }
        public ICollection<Product> Products { get; set; } = default!;
    }
}
