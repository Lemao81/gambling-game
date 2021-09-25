using System.Threading.Tasks;
using GamblingGame.Api.Models.Dtos;
using GamblingGame.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamblingGame.Api.Controllers
{
    [Route("api/Gambling")]
    [ApiController]
    public class GamblingController : ControllerBase
    {
        private readonly IGamblingService _gamblingService;

        public GamblingController(IGamblingService gamblingService)
        {
            _gamblingService = gamblingService;
        }

        [Authorize]
        [HttpPost("Gamble")]
        public async Task<ActionResult<GambleResponse>> Gamble(GambleRequest request)
        {
            var gambleResult = await _gamblingService.GambleAsync(request.Points, request.Number);
            var response = new GambleResponse
            {
                Account = gambleResult.AccountPoints,
                Status = gambleResult.Status,
                Points = gambleResult.PointsString
            };

            return Ok(response);
        }
    }
}
