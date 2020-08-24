using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chapter01
{
    using static Console;

    public static class HOF
    {
        public static void WriteEach<T>(this IEnumerable<T> source)
        {
            foreach (var enumerable in source)
                WriteLine(enumerable);
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var enumerable in source)
            {
                if (predicate(enumerable))
                    yield return enumerable;
            }
        }

        public static Func<T2, T1, R> SwapArgs<T1, T2, R>(this Func<T1, T2, R> f)
            => (t2, t1) => f(t1, t2);

        internal static void Run()
        {
            Func<double, double, double> divide = (dividend, divisor) => dividend / divisor;
            WriteLine(divide(10, 2));

            var divideBy = divide.SwapArgs();
            WriteLine(divideBy(2, 10));
        }
    }
}
