using System.ComponentModel.DataAnnotations;

namespace GamblingGame.Api.Models.Dtos
{
    public class GambleRequest
    {
        [Required]
        public int Points { get; set; }

        [Required]
        public int Number { get; set; }
    }
}
