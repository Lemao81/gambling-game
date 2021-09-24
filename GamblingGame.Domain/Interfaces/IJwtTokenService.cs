using System;

namespace GamblingGame.Domain.Interfaces
{
    public interface IJwtTokenService
    {
        string CreateToken(Guid userId);
    }
}
