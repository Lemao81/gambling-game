namespace GamblingGame.Domain.Exceptions
{
    public class OverdraftException : DomainException
    {
        public OverdraftException()
        {
        }

        public override string Reason => "Not enough points on the account to make this bet";
    }
}
