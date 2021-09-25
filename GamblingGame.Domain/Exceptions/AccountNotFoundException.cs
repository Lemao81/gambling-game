using System;

namespace GamblingGame.Domain.Exceptions
{
    public class AccountNotFoundException : DomainException
    {
        public AccountNotFoundException()
        {
        }

        public AccountNotFoundException(Guid id, bool isUserId = false) : base($"Account with {(isUserId ? "userId" : "id")} {id} not found")
        {
        }

        public override string Reason => "A user account doesn't exist";
    }
}
