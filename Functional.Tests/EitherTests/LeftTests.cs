using NUnit.Framework;

namespace Functional.Tests
{
    using static F;

    public sealed class LeftTests : EitherTestFixture
    {
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

        [TestCase("hello", ExpectedResult = "Invalid value: hello")]
        public string RenderReturnsTheCorrectValue(string value)
        {
            return Test(
                arrange: _ => Left(value),
                act: left => Render(left));
        }
    }
}
