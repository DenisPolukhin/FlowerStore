namespace FlowStoreBackend.Logic.Models.User
{
    public class UpdateUserProfileModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public Guid? CityId { get; set; }
    }
}
