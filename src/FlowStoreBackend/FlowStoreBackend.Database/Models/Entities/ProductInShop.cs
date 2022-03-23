namespace FlowStoreBackend.Database.Models.Entities
{
    public class ProductInShop
    {
        public Guid ShopId { get; set; }
        public Shop Shop { get; set; } = default!;
        public long QuantityInStock { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;
    }
}
