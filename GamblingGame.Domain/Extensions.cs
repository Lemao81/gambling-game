using System.Collections.Generic;
using System.Linq;

namespace GamblingGame.Domain
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable) => enumerable == null || !enumerable.Any();
    }
}
