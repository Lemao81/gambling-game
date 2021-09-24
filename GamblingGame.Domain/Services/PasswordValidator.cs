using System.Collections.Generic;
using System.Linq;
using GamblingGame.Domain.Interfaces;

namespace GamblingGame.Domain.Services
{
    public class PasswordValidator : IPasswordValidator
    {
        public ICollection<string> Validate(string password)
        {
            var errors = new List<string>();

            if (password.Length < 6)
            {
                errors.Add("Password must consist of at least 6 characters");
            }

            if (!password.Any(char.IsUpper))
            {
                errors.Add("Password must contain an upper letter");
            }

            if (!"?:_!#".Any(password.Contains))
            {
                errors.Add("Password must contain a special character '?:_!#'");
            }

            return errors;
        }
    }
}
