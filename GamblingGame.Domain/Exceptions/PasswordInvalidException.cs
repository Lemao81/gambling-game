using System.Collections.Generic;

namespace GamblingGame.Domain.Exceptions
{
    public class PasswordInvalidException : DomainException
    {
        public PasswordInvalidException()
        {
        }

        public PasswordInvalidException(IEnumerable<string> errors) : base($"Password is invalid: {string.Join(". ", errors)}")
        {
        }

        public override string Reason => "Given password is not valid";
    }
}
