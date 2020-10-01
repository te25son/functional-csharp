using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Functional
{
    using static F;
    using Unit = ValueTuple;

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

        public static IEnumerable<Unit> ForEach<T>(this IEnumerable<T> ts, Action<T> action) =>
            ts.Map(action.ToFunc()).ToImmutableList();

        public static Option<Unit> ForEach<T>(this Option<T> t, Action<T> action) =>
            t.Map(action.ToFunc());

        public static Option<R> Bind<T, R>(this Option<T> optT, Func<T, Option<R>> func) =>
            optT.Match(
                () => None,
                (t) => func(t));

        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> ts, Func<T, IEnumerable<R>> func)
        {
            foreach (T t in ts)
                foreach (R r in func(t))
                    yield return r;
        }
    }
}
