using System;

namespace GamblingGame.Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException()
        {
        }

        protected DomainException(string message) : base(message)
        {
        }

        public abstract string Reason { get; }
    }
}
