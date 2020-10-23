using Examples.Tests;
using NUnit.Framework;

namespace Functional.Tests
{
    using static F;

    public sealed class EitherTests : TestFixture
    {
        [TestCase(12, ExpectedResult = "Right(12)")]
        [TestCase("hello", ExpectedResult = "Right(hello)")]
        [TestCase(true, ExpectedResult = "Right(True)")]
        public string RightCanBeConvertedToString(object value)
        {
            return Test(
                _ => Right(value),
                right => right.ToString()
            );
        }

        [TestCase(12, ExpectedResult = "Left(12)")]
        [TestCase("hello", ExpectedResult = "Left(hello)")]
        [TestCase(true, ExpectedResult = "Left(True)")]
        public string LeftCanBeConvertedToString(object value)
        {
            return Test(
                _ => Left(value),
                left => left.ToString()
            );
        }
    }
}
