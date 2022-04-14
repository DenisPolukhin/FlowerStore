using FlowStoreBackend.Database.Models.Enums;
using FlowStoreBackend.Logic.Models.Product;

namespace FlowStoreBackend.Logic.Models.Order
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public PaymentState PaymentState { get; set; }
        public IEnumerable<PaidProductModel> ProductsInOrder { get; set; } = default!;
    }
}
