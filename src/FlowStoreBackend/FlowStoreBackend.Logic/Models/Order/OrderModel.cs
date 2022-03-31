using FlowStoreBackend.Logic.Models.Product;

namespace FlowStoreBackend.Logic.Models.Order
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<ProductModel> Products { get; set; } = default!;
    }
}
