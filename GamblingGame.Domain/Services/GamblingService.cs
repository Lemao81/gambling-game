using System.Threading.Tasks;
using GamblingGame.Domain.Exceptions;
using GamblingGame.Domain.Interfaces;
using GamblingGame.Domain.Models;

namespace GamblingGame.Domain.Services
{
    public class GamblingService : IGamblingService
    {
        private readonly IAuthenticateContext _authenticateContext;
        private readonly IAccountRepository _accountRepository;
        private readonly ILotteryWheel _lotteryWheel;

        public GamblingService(IAuthenticateContext authenticateContext, IAccountRepository accountRepository, ILotteryWheel lotteryWheel)
        {
            _authenticateContext = authenticateContext;
            _accountRepository = accountRepository;
            _lotteryWheel = lotteryWheel;
        }

        public async Task<GambleResult> GambleAsync(int betPoints, int tip)
        {
            var account = await ValidateAccount(betPoints);
            var draw = _lotteryWheel.GetRandomNumber();
            var result = GetGambleResult(betPoints, tip, draw, account);
            await UpdateAccount(account, result);

            return result;
        }

        private async Task<Account> ValidateAccount(int betPoints)
        {
            var account = await _accountRepository.GetByUserIdAsync(_authenticateContext.UserId);
            if (account.Points < betPoints)
            {
                throw new OverdraftException();
            }

            return account;
        }

        private static GambleResult GetGambleResult(int betPoints, int tip, int draw, Account account) =>
            draw != tip ? GambleResult.Failure(betPoints, account.Points) : GambleResult.Success(betPoints, account.Points);

        private async Task UpdateAccount(Account account, GambleResult result)
        {
            account.Points = result.AccountPoints;
            await _accountRepository.UpdateAsync(account);
        }
    }
}
