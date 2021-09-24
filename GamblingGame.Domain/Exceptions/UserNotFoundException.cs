using System;

namespace GamblingGame.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(Guid id) : base($"User with id {id} not found")
        {
        }
    }
}
