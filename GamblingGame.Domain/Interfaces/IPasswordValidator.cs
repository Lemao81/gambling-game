using System.Collections.Generic;

namespace GamblingGame.Domain.Interfaces
{
    public interface IPasswordValidator
    {
        ICollection<string> Validate(string password);
    }
}
