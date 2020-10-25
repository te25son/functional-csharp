using System;

namespace Functional
{
    public struct Right<R>
    {
        internal R Value { get; }

        internal Right(R value) { Value = value; }

        public override string ToString() => $"Right({Value})";

        public Either<L, RR> Bind<L, RR>(Func<R, Either<L, RR>> f) => f(Value);
    }
}
