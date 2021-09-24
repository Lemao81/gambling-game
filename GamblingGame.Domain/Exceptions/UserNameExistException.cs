using System;

namespace GamblingGame.Domain.Exceptions
{
    public class UserNameExistException : Exception
    {
        public UserNameExistException()
        {
        }

        public UserNameExistException(string userName) : base($"A user with name {userName} exist already")
        {
        }
    }
}
