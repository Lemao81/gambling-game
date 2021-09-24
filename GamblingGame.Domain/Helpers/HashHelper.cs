using System.Security.Cryptography;
using System.Text;

namespace GamblingGame.Domain.Helpers
{
    public static class HashHelper
    {
        public static string CreateSha256Hash(string text)
        {
            using var sha256 = SHA256.Create();
            var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            var builder = new StringBuilder();
            foreach (var b in hashBytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
