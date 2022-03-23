namespace FlowStoreBackend.Database.Models.Entities
{
    public class Shop
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public Guid CityId { get; set; }
        public City City { get; set; } = default!;
        public ICollection<Product> Products { get; set; } = default!;
        public ICollection<ProductInShop> ProductsInShop { get; set; } = default!;
        public ICollection<User> Employees { get; set; } = default!;
        public ICollection<ShopEmployees> ShopEmployees { get; set; } = default!;
    }
}
