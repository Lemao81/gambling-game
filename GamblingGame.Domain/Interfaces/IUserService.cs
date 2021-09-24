using System.Threading.Tasks;

namespace GamblingGame.Domain.Interfaces
{
    public interface IUserService
    {
        Task RegisterUserAsync(string userName, string password);
        Task<string> LoginAsync(string userName, string password);
    }
}
