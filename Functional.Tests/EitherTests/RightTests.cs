using NUnit.Framework;

namespace Functional.Tests
{
    using static F;

    public sealed class RightTests : EitherTestFixture
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

        [TestCase(12d, ExpectedResult = "The result is: 12")]
        public string RenderReturnsTheCorrectValue(double value)
        {
            return Test(
                arrange: _ => Right(value),
                act: right => Render(right));
        }
    }
}
