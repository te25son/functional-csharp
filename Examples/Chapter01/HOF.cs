using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chapter01
{
    public static class HOF
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var enumerable in source)
            {
                if (predicate(enumerable))
                    yield return enumerable;
            }
        }
    }
}
