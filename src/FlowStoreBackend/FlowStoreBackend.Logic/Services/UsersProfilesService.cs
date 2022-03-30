using AutoMapper;
using FlowStoreBackend.Common.Exceptions;
using FlowStoreBackend.Database.Models;
using FlowStoreBackend.Logic.Interfaces;
using FlowStoreBackend.Logic.Models.User;
using Microsoft.EntityFrameworkCore;

namespace FlowStoreBackend.Logic.Services
{
    public class UsersProfilesService : IUsersProfilesService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public UsersProfilesService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<UserProfileModel> ReadProfileAsync(Guid userId)
        {
            var user = await _databaseContext.Users
                .Include(x => x.City)
                .FirstOrDefaultAsync(x => x.Id == userId);

            return _mapper.Map<UserProfileModel>(user);
        }

        public async Task UpdateProfileAsync(Guid userId, UpdateUserProfileModel profileModel)
        {
            var user = await _databaseContext.Users.FindAsync(userId);
            if (profileModel.CityId != null && await _databaseContext.Cities
                .AnyAsync(x => x.Id == profileModel.CityId))
            {
                throw new EntityFindException();
            }

            _mapper.Map(profileModel, user);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
