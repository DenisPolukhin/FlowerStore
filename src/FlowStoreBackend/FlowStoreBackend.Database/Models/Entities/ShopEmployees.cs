namespace FlowStoreBackend.Database.Models.Entities
{
    public class ShopEmployees
    {
        public Guid ShopId { get; set; }
        public Shop Shop { get; set; } = default!;
        public bool IsAdministrator { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
