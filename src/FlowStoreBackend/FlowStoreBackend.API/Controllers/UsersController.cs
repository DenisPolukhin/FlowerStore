using FlowStoreBackend.Logic.Interfaces;
using FlowStoreBackend.Logic.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowStoreBackend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

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
    }
}