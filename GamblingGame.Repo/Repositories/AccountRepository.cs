using System;
using System.Threading.Tasks;
using GamblingGame.Domain.Exceptions;
using GamblingGame.Domain.Interfaces;
using GamblingGame.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GamblingGame.Repo.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly GamblingGameDbContext _dbContext;

        public AccountRepository(GamblingGameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Account> GetByIdAsync(Guid id) => await _dbContext.Accounts.FindAsync(id) ?? throw new AccountNotFoundException(id);

        public async Task<Account> GetByUserIdAsync(Guid userId) => await _dbContext.Accounts.SingleOrDefaultAsync(a => a.UserId == userId) ??
                                                                    throw new AccountNotFoundException(userId, true);

        public async Task<Account> UpdateAsync(Account account)
        {
            account.LastModified = DateTime.Now;
            var entry = _dbContext.Accounts.Update(account);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
