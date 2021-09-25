using System;
using GamblingGame.Domain.Interfaces;

namespace GamblingGame.Domain.Models
{
    public class AuthenticateContext : IAuthenticateContext
    {
        public Guid UserId { get; set; }
    }
}
