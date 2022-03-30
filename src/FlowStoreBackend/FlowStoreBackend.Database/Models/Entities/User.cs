using Microsoft.AspNetCore.Identity;
using NodaTime;

namespace FlowStoreBackend.Database.Models.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? MiddleName { get; set; }
        public Instant LastSeenAt { get; set; } = SystemClock.Instance.GetCurrentInstant();
        public Guid? CityId { get; set; }
        public City? City { get; set; }
        public ICollection<Order> Orders { get; set; } = default!;
        public ICollection<Shop> Shops { get; set; } = default!;
        public ICollection<ShopEmployees> ShopEmployees { get; set; } = default!;
    }
}