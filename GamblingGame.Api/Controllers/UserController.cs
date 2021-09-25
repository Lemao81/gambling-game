using System.Threading.Tasks;
using GamblingGame.Api.Models.Dtos;
using GamblingGame.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamblingGame.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            await _userService.RegisterUserAsync(request.UserName, request.Password);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            var token = await _userService.LoginAsync(request.UserName, request.Password);
            var response = new LoginResponse
            {
                AccessToken = token
            };

            return Ok(response);
        }
    }
}
