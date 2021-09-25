using GamblingGame.Domain.Enums;

namespace GamblingGame.Api.Models.Dtos
{
    public class GambleResponse
    {
        public int Account { get; set; }
        public GambleStatus Status { get; set; }
        public string Points { get; set; }
    }
}
