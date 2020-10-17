using Examples.Chapter04;
using NUnit.Framework;

namespace Examples.Tests.Chapter04.Naturals
{
    public class NaturalTests : TestFixture
    {
        [TestCase("2", "2")]
        [TestCase("0", "0")]
        [TestCase("-2", "None")]
        [TestCase("Hello", "None")]
        public void NaturalTest(string value, string expectedResult)
        {
            Test(
                arrange: _ => new Natural(value),
                act: arrangeResult => arrangeResult.ToNatural(),
                assert: (arrangeResult, actResult) => Assert.AreEqual(expectedResult, actResult.ToString())
            );
        }
    }
}
