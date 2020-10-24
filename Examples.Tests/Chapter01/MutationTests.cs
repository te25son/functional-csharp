using Functional;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Tests.Chapter01
{
    class MutationTests : TestFixture
    {
        [Test]
        public void NoInPlaceUpdates()
        {
            Test(
                arrange: _ => new[] { 5, 7, 1 },
                act: arrangeResult => arrangeResult.OrderBy(x => x).ToList(),
                assert: (arrangeResult, actResult) =>
                {
                    Assert.AreEqual(new[] { 5, 7, 1 }, arrangeResult);
                    Assert.AreEqual(new[] { 1, 5, 7 }, actResult);
                }
            );
        }

        [Test]
        public void InPlaceUpdates()
        {
            Test(
                arrange: _ => new List<int> { 5, 7, 1 },
                act: arrangeResult =>
                {
                    arrangeResult.Sort();
                    return Unit.Value;
                },
                assert: (arrangeResult, _) => Assert.AreEqual(new[] { 1, 5, 7 }, arrangeResult)
            );
        }
    }
}
