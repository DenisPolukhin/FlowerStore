namespace FlowStoreBackend.Database.Models.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public ICollection<Order> Orders { get; set; } = default!;
        public ICollection<PriceHistory> PriceHistory { get; set; } = default!;
        public ICollection<Shop> Shops { get; set; } = default!;
        public ICollection<ProductInShop> ProductsInShop { get; set; } = default!;
        public ICollection<ProductInOrder> ProductInOrders { get; set; } = default!;
    }
}