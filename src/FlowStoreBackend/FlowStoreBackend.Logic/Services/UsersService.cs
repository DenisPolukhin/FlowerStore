using FlowStoreBackend.Database.Models;
using FlowStoreBackend.Database.Models.Entities;
using FlowStoreBackend.Logic.Interfaces;
using FlowStoreBackend.Logic.Models;
using FlowStoreBackend.Logic.Models.User;
using Microsoft.AspNetCore.Identity;
using NodaTime;

namespace FlowStoreBackend.Logic.Services
{
    public class UsersService : IUsersService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IJwtService _jwtService;
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;
        //public UsersService(DatabaseContext databaseContext, IJwtService jwtService,
        //    UserManager<User> userManager, SignInManager<User> signInManager)
        //{
        //    _databaseContext = databaseContext;
        //    _jwtService = jwtService;
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}
        public async Task<LoginResultModel> LogInAsync(LogInModel logInModel)
        {
            //const string InvalidLoginOrPasswordMessage = "You entered an incorrect username or password";
            //var user = await _databaseContext.Users.FindAsync(logInModel.Email);
            //if(user is null)
            //{
            //    return new LoginResultModel(false, InvalidLoginOrPasswordMessage);
            //}

            //var signInResult = await _signInManager.CheckPasswordSignInAsync(user, logInModel.Password, false);
            //if (!signInResult.Succeeded)
            //{
            //    return new LoginResultModel(false, InvalidLoginOrPasswordMessage);
            //}

            //user.LastSeenAt = SystemClock.Instance.GetCurrentInstant();
            //await _databaseContext.SaveChangesAsync();

            throw new NotImplementedException();
        }

        public Task<Result> SignUpAsync(SignUpModel signUpModel)
        {
            throw new NotImplementedException();
        }

        private LoginResultModel GenerateSuccessfulLoginResultModel(User user)
        {
            throw new NotImplementedException();
        }
    }
}
