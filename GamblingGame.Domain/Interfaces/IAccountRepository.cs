using System;
using System.Threading.Tasks;
using GamblingGame.Domain.Models;

namespace GamblingGame.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(Guid id);
        Task<Account> GetByUserIdAsync(Guid userId);
        Task<Account> UpdateAsync(Account account);
    }
}
