using Examples.Tests;

namespace Functional.Tests
{
    public sealed class EitherTests : TestFixture
    {
        public string RightCanBeConvertedToString(object value)
        {
            Test(
                _ => Right())
        }
    }
}
