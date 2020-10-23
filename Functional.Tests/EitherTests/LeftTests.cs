using Examples.Tests;
using NUnit.Framework;

namespace Functional.Tests
{
    using static F;

    public sealed class LeftTests : TestFixture
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
    }
}
