using System;

namespace GamblingGame.Domain.Exceptions
{
    public class UserNameNotExistException : Exception
    {
        public UserNameNotExistException()
        {
        }

        public UserNameNotExistException(string userName) : base($"A user with name {userName} doesn't exist")
        {
        }
    }
}
