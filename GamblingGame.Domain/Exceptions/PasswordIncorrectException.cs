using System;

namespace GamblingGame.Domain.Exceptions
{
    public class PasswordIncorrectException : DomainException
    {
        public PasswordIncorrectException() : base("Incorrect Password")
        {
        }

        public override string Reason => "Password is incorrect";
    }
}
