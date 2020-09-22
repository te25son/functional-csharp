using System;

namespace Functional
{
    using Unit = System.ValueTuple;
    using static F;

    public static partial class F
    {
        public static Unit Unit() => default;
    }

    public static class ActionExtensions
    {
        public static R Using<TDisp, R>(TDisp disposable, Func<TDisp, R> func)
            where TDisp : IDisposable
        {
            using (disposable) return func(disposable);
        }

        public static Func<Unit> ToFunc(this Action action) =>
            () => { action(); return Unit(); };

        public static Func<T, Unit> ToFunc<T>(this Action<T> action) =>
            (t) => { action(t); return Unit(); };

        public static Func<T1, T2, Unit> ToFunc<T1, T2>(this Action<T1, T2> action) =>
            (t1, t2) => { action(t1, t2); return Unit(); };

        public static Func<T1, T2, T3, Unit> ToFunc<T1, T2, T3>(this Action<T1, T2, T3> action) =>
            (t1, t2, t3) => { action(t1, t2, t3); return Unit(); };
    }
}
