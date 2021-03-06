namespace FlowStoreBackend.Database.Models.Entities
{
    public class ProductInOrder
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = default!;
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public int Quantity { get; set; }
    }
}
