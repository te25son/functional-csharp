using Functional.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functional
{
    using static F;

    public static class Core
    {
        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts, Func<T, R> func)
        {
            foreach (var t in ts)
                yield return func(t);
        }

        public static Option<R> Map<T, R>(this Option<T> optT, Func<T, R> func) =>
            optT.Match(
                () => None,
                t => Some(func(t)));
    }
}
