using System.Threading.Tasks;
using GamblingGame.Api.Models.Dtos;
using GamblingGame.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamblingGame.Api.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            await _userService.RegisterUserAsync(request.UserName, request.Password);

            return Ok();
        }

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
