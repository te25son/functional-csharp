using Examples.Tests;
using NUnit.Framework;
using System.Linq;

namespace Functional.Tests.Option
{
    using static F;

    public sealed class OptionTests : TestFixture
    {
        [Test]
        public void SomeConvertsToEnumerableOfOne()
        {
            Test(
                arrange: _ => Some("thing"),
                act: arrangeResult => arrangeResult.AsEnumerable(),
                assert: (arrangeResult, actResult) => Assert.AreEqual(1, actResult.Count())
            );
        }
    }
}
