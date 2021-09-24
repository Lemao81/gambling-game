using System;
using System.Collections.Generic;

namespace GamblingGame.Domain.Exceptions
{
    public class PasswordInvalidException : Exception
    {
        public PasswordInvalidException()
        {
        }

        public PasswordInvalidException(IEnumerable<string> errors) : base($"Password is invalid: {string.Join(". ", errors)}")
        {
        }
    }
}
