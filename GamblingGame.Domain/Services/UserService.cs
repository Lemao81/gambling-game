using System.Linq;
using System.Threading.Tasks;
using GamblingGame.Domain.Consts;
using GamblingGame.Domain.Exceptions;
using GamblingGame.Domain.Helpers;
using GamblingGame.Domain.Interfaces;
using GamblingGame.Domain.Models;

namespace GamblingGame.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordValidator _passwordValidator;
        private readonly IJwtTokenService _jwtTokenService;

        public UserService(IUserRepository userRepository, IPasswordValidator passwordValidator, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _passwordValidator = passwordValidator;
            _jwtTokenService = jwtTokenService;
        }

        public async Task RegisterUserAsync(string userName, string password)
        {
            var userNameExist = await _userRepository.AnyAsync(u => u.UserName == userName);
            if (userNameExist)
            {
                throw new UserNameExistException(userName);
            }

            var errors = _passwordValidator.Validate(password);
            if (errors.Any())
            {
                throw new PasswordInvalidException(errors);
            }

            var user = new User
            {
                UserName = userName,
                PasswordHash = HashHelper.CreateSha256Hash(password),
                Account = new Account
                {
                    Points = Const.AccountStartPoints
                }
            };

            await _userRepository.AddAsync(user);
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            var user = await _userRepository.GetByUserNameAsync(userName);
            if (user.PasswordHash != HashHelper.CreateSha256Hash(password))
            {
                throw new PasswordIncorrectException();
            }

            return _jwtTokenService.CreateToken(user.Id);
        }
    }
}
