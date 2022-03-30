namespace FlowStoreBackend.Logic.Models.User
{
    public record UpdateUserProfileModel(string? FirstName, string? LastName,
        string? MiddleName, Guid? CityId);

}
