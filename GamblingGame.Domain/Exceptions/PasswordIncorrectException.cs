using System;

namespace GamblingGame.Domain.Exceptions
{
    public class PasswordIncorrectException : Exception
    {
        public PasswordIncorrectException() : base("Password is incorrect")
        {
        }
    }
}
