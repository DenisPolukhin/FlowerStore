namespace FlowStoreBackend.Logic.Models.Product
{
    public class PaidProductModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
