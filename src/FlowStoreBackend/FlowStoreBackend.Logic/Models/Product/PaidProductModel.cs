namespace FlowStoreBackend.Logic.Models.Product
{
    public class PaidProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
