using System;
using GamblingGame.Domain.Interfaces;

namespace GamblingGame.Domain.Models
{
    public class AuthenticateContext : IAuthenticateContext
    {
        private Guid _userId;

        public Guid UserId
        {
            get
            {
                if (_userId == default)
                {
                    throw new UnauthorizedAccessException();
                }

                return _userId;
            }
            set => _userId = value;
        }
    }
}
