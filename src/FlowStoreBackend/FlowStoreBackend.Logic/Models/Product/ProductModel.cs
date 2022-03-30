namespace FlowStoreBackend.Logic.Models.Product
{
    public record ProductModel(Guid Id, string Name, string Description,
        decimal Price);
}
