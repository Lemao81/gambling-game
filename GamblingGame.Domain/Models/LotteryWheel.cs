using System;
using GamblingGame.Domain.Consts;
using GamblingGame.Domain.Interfaces;

namespace GamblingGame.Domain.Models
{
    public class LotteryWheel : ILotteryWheel
    {
        public int GetRandomNumber() => new Random(DateTime.Now.Millisecond).Next(Const.GambleDrawUpperLimit + 1);
    }
}
