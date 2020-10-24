using Examples.Tests;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace Functional.Tests
{
    using static F;

    public sealed class EitherTests : EitherTestFixture
    {
        [TestCase(3, 0, ExpectedResult = "Left(y cannot be 0)")]
        [TestCase(-3, 3, ExpectedResult = "Left(x / y cannot be negative)")]
        [TestCase(-3, -3, ExpectedResult = "Right(1)")]
        [TestCase(3, 3, ExpectedResult = "Right(1)")]
        public string CalcReturnsCorrectResponse(double x, double y)
        {
            return Test(
                arrange: _ => Calc(x, y),
                act: either => either.ToString());
        }
    }
}
