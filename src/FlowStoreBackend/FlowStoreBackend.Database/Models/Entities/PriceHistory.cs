using NodaTime;

namespace FlowStoreBackend.Database.Models.Entities
{
    public class PriceHistory
    {
        public Guid Id { get; set; }
        public Instant UpdatedAt { get; set; } = SystemClock.Instance.GetCurrentInstant();
        public decimal OldPrice { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;

    }
}
