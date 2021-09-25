using GamblingGame.Domain.Consts;
using GamblingGame.Domain.Enums;

namespace GamblingGame.Domain.Models
{
    public class GambleResult
    {
        private GambleResult(GambleStatus status, string pointsString, int accountPoints)
        {
            Status = status;
            PointsString = pointsString;
            AccountPoints = accountPoints;
        }

        public GambleStatus Status { get; }
        public string PointsString { get; }
        public int AccountPoints { get; }

        public static GambleResult Failure(int betPoints, int currentAccountPoints) =>
            new(GambleStatus.Lost, GetPointsString(-betPoints), currentAccountPoints - betPoints);

        public static GambleResult Success(int betPoints, int currentAccountPoints)
        {
            var winPoints = betPoints * Const.GambleWinFactor;

            return new(GambleStatus.Won, GetPointsString(winPoints), currentAccountPoints + winPoints);
        }

        private static string GetPointsString(int amount) => $"{(amount >= 0 ? "+" : "")}{amount}";
    }
}
