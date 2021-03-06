using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GamblingGame.Domain.Exceptions;
using GamblingGame.Domain.Interfaces;
using GamblingGame.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GamblingGame.Repo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GamblingGameDbContext _dbContext;

        public UserRepository(GamblingGameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddAsync(User user)
        {
            var entry = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<User> GetByIdAsync(Guid id) => await _dbContext.Users.FindAsync(id) ?? throw new UserNotFoundException(id);

        public async Task<User> GetByUserNameAsync(string userName) => await _dbContext.Users.SingleOrDefaultAsync(u => u.UserName == userName) ??
                                                                       throw new UserNameNotExistException(userName);

        public async Task<bool> AnyAsync(Expression<Func<User, bool>> predicate) => await _dbContext.Users.AnyAsync(predicate);
    }
}
