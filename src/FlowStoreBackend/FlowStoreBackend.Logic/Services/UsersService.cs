using FlowStoreBackend.Database.Models;
using FlowStoreBackend.Database.Models.Entities;
using FlowStoreBackend.Logic.Interfaces;
using FlowStoreBackend.Logic.Models;
using FlowStoreBackend.Logic.Models.User;
using Microsoft.AspNetCore.Identity;
using NodaTime;
using System.Security.Claims;

namespace FlowStoreBackend.Logic.Services
{
    public class UsersService : IUsersService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UsersService(DatabaseContext databaseContext, IJwtService jwtService,
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _databaseContext = databaseContext;
            _jwtService = jwtService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<LoginResultModel> LogInAsync(LogInModel logInModel)
        {
            const string InvalidLoginOrPasswordMessage = "You entered an incorrect username or password";
            var user = await _userManager.FindByEmailAsync(logInModel.Email);
            if (user is null)
            {
                return new LoginResultModel(false, InvalidLoginOrPasswordMessage);
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, logInModel.Password, false);
            if (!signInResult.Succeeded)
            {
                return new LoginResultModel(false, InvalidLoginOrPasswordMessage);
            }

            user.LastSeenAt = SystemClock.Instance.GetCurrentInstant();
            await _databaseContext.SaveChangesAsync();

            return await GenerateSuccessfulLoginResultModelAsync(user);
        }

        public async Task<Result> SignUpAsync(SignUpModel signUpModel)
        {
            var user = await _userManager.FindByEmailAsync(signUpModel.Email);
            if (user is not null)
            {
                return new Result(false, "User with this email already exists");
            }

            user = new User
            {
                UserName = signUpModel.Email,
                Email = signUpModel.Email
            };

            var result = await _userManager.CreateAsync(user, signUpModel.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Aggregate("", (current, e) => current + e.Description + "\n");
                return new Result(false, errors);
            }

            return new Result(true, "Successful");
        }

        private async Task<LoginResultModel> GenerateSuccessfulLoginResultModelAsync(User user)
        {
            var accessTokenPayload = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                accessTokenPayload.Add(new Claim(ClaimTypes.Role, role));
            }

            var accessToken = _jwtService.GenerateSuccessfulAccessToken(accessTokenPayload);
            return new LoginResultModel(true, "Successful", accessToken);
        }
    }
}