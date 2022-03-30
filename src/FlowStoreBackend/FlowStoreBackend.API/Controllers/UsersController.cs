using FlowStoreBackend.Logic.Interfaces;
using FlowStoreBackend.Logic.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlowStoreBackend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IUsersProfilesService _usersProfilesService;
        public UsersController(IUsersService usersService, IUsersProfilesService usersProfilesService)
        {
            _usersService = usersService;
            _usersProfilesService = usersProfilesService;
        }

        private Guid UserId => Guid.ParseExact(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value, "D");

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await _usersService.SignUpAsync(signUpModel);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> LogIn(LogInModel logInModel)
        {
            var result = await _usersService.LogInAsync(logInModel);
            return Ok(result);
        }

        [HttpGet("Profile")]
        public async Task<IActionResult> ReadProfile()
        {
            var result = await _usersProfilesService.ReadProfileAsync(UserId);
            return Ok(result);
        }

        [HttpPatch("Profile")]
        public async Task<IActionResult> UpdateProfile(UpdateUserProfileModel profileModel)
        {
            await _usersProfilesService.UpdateProfileAsync(UserId, profileModel);
            return NoContent();
        }
    }
}