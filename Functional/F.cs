﻿using System;

namespace Functional
{
    public static class ActionExtensions
    {
        public static Func<Unit> ToFunc(this Action action) =>
            () => { action(); return Unit.Value; };

        public static Func<T, Unit> ToFunc<T>(this Action<T> action) =>
            (t) => { action(t); return Unit.Value; };

        public static Func<T1, T2, Unit> ToFunc<T1, T2>(this Action<T1, T2> action) =>
            (t1, t2) => { action(t1, t2); return Unit.Value; };

        public static Func<T1, T2, T3, Unit> ToFunc<T1, T2, T3>(this Action<T1, T2, T3> action) =>
            (t1, t2, t3) => { action(t1, t2, t3); return Unit.Value; };

        // Can make more overloads to handle more arguments...
    }
}
