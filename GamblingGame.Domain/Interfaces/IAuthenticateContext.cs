using System;

namespace GamblingGame.Domain.Interfaces
{
    public interface IAuthenticateContext
    {
        Guid UserId { get; set; }
    }
}
