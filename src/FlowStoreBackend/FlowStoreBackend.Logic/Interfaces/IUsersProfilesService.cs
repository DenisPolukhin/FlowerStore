using FlowStoreBackend.Logic.Models.User;

namespace FlowStoreBackend.Logic.Interfaces
{
    public interface IUsersProfilesService
    {
        Task<UserProfileModel> ReadProfileAsync(Guid userId);
        Task UpdateProfileAsync(Guid userId, UpdateUserProfileModel profileModel);
    }
}
