using System;

namespace GamblingGame.Domain.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException()
        {
        }

        public AccountNotFoundException(Guid id, bool isUserId = false) : base($"Account with {(isUserId ? "userId" : "id")} {id} not found")
        {
        }
    }
}
