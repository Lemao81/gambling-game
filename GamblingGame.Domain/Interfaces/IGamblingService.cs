using System.Threading.Tasks;
using GamblingGame.Domain.Models;

namespace GamblingGame.Domain.Interfaces
{
    public interface IGamblingService
    {
        Task<GambleResult> GambleAsync(int betPoints, int tip);
    }
}
