using Examples.Tests;
using System;

namespace Functional.Tests
{
    using static Math;

    public class EitherTestFixture : TestFixture
    {
        public string Render(Either<string, double> val) =>
            val.Match(
                l: l => $"Invalid value: {l}",
                r: r => $"The result is: {r}");

        public  Either<string, double> Calc(double x, double y)
        {
            if (y == 0)
                return "y cannot be 0";

            if (x != 0 && Sign(x) != Sign(y))
                return "x / y cannot be negative";

            return Sqrt(x / y);
        }
    }
}
