using AutoMapper;
using FlowStoreBackend.Database.Models.Entities;
using FlowStoreBackend.Logic.Models.User;

namespace FlowStoreBackend.Logic.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserProfileModel>();
            CreateMap<UpdateUserProfileModel, User>();
        }
    }
}
