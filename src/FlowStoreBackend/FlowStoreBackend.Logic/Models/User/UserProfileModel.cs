namespace FlowStoreBackend.Logic.Models.User
{
    public record UserProfileModel(string? FirstName, string? LastName,
        string? MiddleName, string? CityName);
}
