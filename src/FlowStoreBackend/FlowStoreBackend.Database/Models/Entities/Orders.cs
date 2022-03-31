using NodaTime;

namespace FlowStoreBackend.Database.Models.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Instant CreatedAt { get; set; } = SystemClock.Instance.GetCurrentInstant();
        public string? Comment { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; } = default!;
        public ICollection<Product> Products { get; set; } = default!;
    }
}
