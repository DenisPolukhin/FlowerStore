namespace FlowStoreBackend.Logic.Models.Product
{
    public record CreateProductModel(string Name, string Description,
        Guid CategoryId, decimal Price);
}
