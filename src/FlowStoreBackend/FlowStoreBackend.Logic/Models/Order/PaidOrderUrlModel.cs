using FlowStoreBackend.Logic.Models.Product;

namespace FlowStoreBackend.Logic.Models.Order
{
    public class PaidOrderUrlModel
    {
        public Guid Id { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhoneNumber { get; set; }
        public IEnumerable<PaidProductModel> Products { get; set; } = default!;
    }
}
