namespace GamblingGame.Domain.Exceptions
{
    public class UserNameNotExistException : DomainException
    {
        public UserNameNotExistException()
        {
        }

        public UserNameNotExistException(string userName) : base($"A user with name {userName} doesn't exist")
        {
        }

        public override string Reason => "Given user name doesn't exist";
    }
}
