using System.ComponentModel.DataAnnotations;

namespace GamblingGame.Api.Models.Dtos
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
