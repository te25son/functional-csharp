using System;

namespace Functional.Either
{
    using static F;
    using Unit = ValueTuple;

    public static class EitherExtensions
    {
        public static Either<L, RR> Map<L, R, RR>(this Either<L, R> either, Func<R, RR> func) =>
            either.Match<Either<L, RR>>(
                l => Left(l),
                r => Right(func(r)));

        public static Either<L, Unit> ForEach<L, R>(this Either<L, R> either, Action<R> act) =>
            Map(either, act.ToFunc());

        public static Either<L, RR> Bind<L, R, RR>(this Either<L, R> either, Func<R, Either<L, RR>> func) =>
            either.Match(
                l => Left(l),
                r => func(r));
    }
}
