namespace GamblingGame.Domain.Exceptions
{
    public class UserNameExistException : DomainException
    {
        public UserNameExistException()
        {
        }

        public UserNameExistException(string userName) : base($"User name {userName} exists already")
        {
        }

        public override string Reason => "User name exists already";
    }
}
