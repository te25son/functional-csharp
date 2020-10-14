using Examples.Chapter04;
using Functional;
using NUnit.Framework;
using System.Linq;

namespace Examples.Tests.Chapter04.FunctorsAndMonads
{
    using static CoreEnumerable;

    public sealed class FunctorMonadTests : TestFixture
    {
        [Test]
        public void CanLiftValueToMonadicValue()
        {
            Test(
                arrange: _ => "hello",
                act: arrangeResult => List(arrangeResult),
                assert: (arrangeResult, actResult) => Assert.IsTrue(actResult.Count().Equals(1))
            );
        }

        [Test]
        public void CanImplementMapInTermsOfBind()
        {
            Test(
                arrange: _ => new[]
                {
                    new Students(1, new[] { "Yellow", "Green" }),
                    new Students(2, new[] { "Purple", "Orange" })
                },
                act: arrangeResult => arrangeResult.Map(s => s.FavoriteColors),
                assert: (arrangeResult, actResult) => Assert.Pass()
            );
        }

        //[Test]
        //public void CannotImplementBindInTermsOfMap()
        //{
        //    Test(
        //        arrange: _ => new[]
        //        {
        //            new Students(1, new[] { "Yellow", "Green" }),
        //            new Students(2, new[] { "Purple", "Orange" })
        //        },
        //        act: arrangeResult => arrangeResult.Bind(s => s.Id),
        //        assert: (arrangeResult, actResult) => Assert.Fail()
        //    );
        //}
    }
}
