using System;

namespace GamblingGame.Domain.Exceptions
{
    public class UserNotFoundException : DomainException
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(Guid id) : base($"User with id {id} not found")
        {
        }

        public override string Reason => "User account wasn't found";
    }
}
