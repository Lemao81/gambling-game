using System;
using System.Threading.Tasks;
using FakeItEasy;
using GamblingGame.Domain.Enums;
using GamblingGame.Domain.Exceptions;
using GamblingGame.Domain.Interfaces;
using GamblingGame.Domain.Models;
using GamblingGame.Domain.Services;
using Xunit;

namespace Tests
{
    public class GamblingServiceTests
    {
        private readonly GamblingService _classUnderTest;
        private readonly IAuthenticateContext _authenticateContextFake;
        private readonly IAccountRepository _accountRepositoryFake;
        private readonly ILotteryWheel _lotteryWheelFake;

        public GamblingServiceTests()
        {
            _authenticateContextFake = A.Fake<IAuthenticateContext>();
            _accountRepositoryFake = A.Fake<IAccountRepository>();
            _lotteryWheelFake = A.Fake<ILotteryWheel>();
            _classUnderTest = new GamblingService(_authenticateContextFake, _accountRepositoryFake, _lotteryWheelFake);
        }

        [Fact]
        public async Task GambleAsync_WinTip_ProperResultReturned()
        {
            // Arrange
            const int betPoints = 250;
            const int tip = 7;
            var account = new Account
            {
                Points = 1000
            };
            A.CallTo(() => _accountRepositoryFake.GetByUserIdAsync(A<Guid>.Ignored)).Returns(account);
            A.CallTo(() => _lotteryWheelFake.GetRandomNumber()).Returns(7);

            // Act
            var result = await _classUnderTest.GambleAsync(betPoints, tip);

            // Assert
            Assert.Equal(3250, result.AccountPoints);
            Assert.Equal("+2250", result.PointsString);
            Assert.Equal(GambleStatus.Won, result.Status);
            A.CallTo(() => _accountRepositoryFake.UpdateAsync(account)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task GambleAsync_LoseTip_ProperResultReturned()
        {
            // Arrange
            const int betPoints = 250;
            const int tip = 7;
            var account = new Account
            {
                Points = 1000
            };
            A.CallTo(() => _accountRepositoryFake.GetByUserIdAsync(A<Guid>.Ignored)).Returns(account);
            A.CallTo(() => _lotteryWheelFake.GetRandomNumber()).Returns(5);

            // Act
            var result = await _classUnderTest.GambleAsync(betPoints, tip);

            // Assert
            Assert.Equal(750, result.AccountPoints);
            Assert.Equal("-250", result.PointsString);
            Assert.Equal(GambleStatus.Lost, result.Status);
            A.CallTo(() => _accountRepositoryFake.UpdateAsync(account)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task GambleAsync_OverdraftTip_ExceptionThrown()
        {
            // Arrange
            const int betPoints = 1100;
            const int tip = 7;
            var account = new Account
            {
                Points = 1000
            };
            A.CallTo(() => _accountRepositoryFake.GetByUserIdAsync(A<Guid>.Ignored)).Returns(account);

            // Act + Assert
            await Assert.ThrowsAsync<OverdraftException>(() => _classUnderTest.GambleAsync(betPoints, tip));
            A.CallTo(() => _accountRepositoryFake.UpdateAsync(account)).MustNotHaveHappened();
        }
    }
}
