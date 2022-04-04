namespace FlowStoreBackend.Logic.Models.Order
{
    public class CreateOrderModel
    {
        public string? Comment { get; set; }
        public List<ProductInOrderModel> Products { get; set; } = default!;
    }
}
