using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GamblingGame.Domain.Models;

namespace GamblingGame.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByUserNameAsync(string userName);
        Task<bool> AnyAsync(Expression<Func<User, bool>> predicate);
    }
}
