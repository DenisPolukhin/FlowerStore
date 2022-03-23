using FlowStoreBackend.Database.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowStoreBackend.Database.Models
{
    public class DatabaseContext : IdentityDbContext<User,IdentityRole<Guid>, Guid>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<PriceHistory> PriceHistory => Set<PriceHistory>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Shop> Shops => Set<Shop>();
        public DbSet<ProductInShop> ProductInShops => Set<ProductInShop>();
        public DbSet<ShopEmployees> ShopEmployees => Set<ShopEmployees>();
        public DbSet<Payment> Payments => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<Shop>()
                .HasMany(s => s.Products)
                .WithMany(p => p.Shops)
                .UsingEntity<ProductInShop>(
                    j => j
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductsInShop)
                .HasForeignKey(ps => ps.ProductId),
                    j => j
                .HasOne(ps => ps.Shop)
                .WithMany(s => s.ProductsInShop)
                .HasForeignKey(ps => ps.ShopId));

            builder
                .Entity<Shop>()
                .HasMany(s => s.Employees)
                .WithMany(e => e.Shops)
                .UsingEntity<ShopEmployees>(
                j => j
                .HasOne(sa => sa.User)
                .WithMany(u => u.ShopEmployees)
                .HasForeignKey(sa => sa.UserId),
                j => j
                .HasOne(sa => sa.Shop)
                .WithMany(s => s.ShopEmployees)
                .HasForeignKey(sa => sa.ShopId));
        }
    }
}