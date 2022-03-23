namespace FlowStoreBackend.Logic.Models
{
    public record LoginResultModel(bool Success, string Message, 
        string? AccessToken = default);
}
