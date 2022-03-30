namespace FlowStoreBackend.Logic.Models.Product
{
    public record UpdateProductModel(string Name, string Description,
        Guid CategoryId, decimal Price);
}
