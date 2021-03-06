﻿using System;

namespace Functional
{
    public static partial class F
    {
        public static Left<L> Left<L>(L l) => new Left<L>(l);
        public static Right<R> Right<R>(R r) => new Right<R>(r);
    }

    public struct Either<L, R>
    {
        internal L Left { get; }
        internal R Right { get; }

        private bool IsRight { get; }
        private bool IsLeft => !IsRight;

        internal Either(L left)
        {
            IsRight = false;
            Left = left;
            Right = default(R);
        }

        internal Either(R right)
        {
            IsRight = true;
            Left = default(L);
            Right = right;
        }

        public static implicit operator Either<L, R>(L left) => new Either<L, R>(left);
        public static implicit operator Either<L, R>(R right) => new Either<L, R>(right);

        public static implicit operator Either<L, R>(Left<L> left) => new Either<L, R>(left.Value);
        public static implicit operator Either<L, R>(Right<R> right) => new Either<L, R>(right.Value);

        public TR Match<TR>(Func<L, TR> left, Func<R, TR> right) =>
            IsLeft ? left(Left) : right(Right);

        public Unit Match(Action<L> left, Action<R> right) =>
            Match(left.ToFunc(), right.ToFunc());

        public override string ToString() =>
            Match(
                l => $"Left({l})",
                r => $"Right({r})");
    }
}
