using Examples.Tests;
using Functional.Option;
using NUnit.Framework;
using System;

namespace Functional.Tests.Core
{
    using static F;

    public class CoreTests : TestFixture
    {
        [TestCase("John")]
        public void MapWithSomeReturnsCorrectType(string name)
        {
            Test(
                arrange: _ => Some(name),
                act: arrangeResult =>
                {
                    Func<string, string> greet = greeteeName => $"Hello, {greeteeName}";
                    return arrangeResult.Map(greet);
                },
                assert: (arrangeResult, actResult) =>
                {
                    Assert.AreEqual(typeof(Option<string>), actResult.GetType());
                }
            );
        }

        [Test]
        public void MapWithNoneReturnsCorrectType()
        {
            Test(
                arrange: _ => (Option<string>)None,
                act: arrangeResult =>
                {
                    Func<string, string> greet = greeteeName => $"Hello, {greeteeName}";
                    return arrangeResult.Map(greet);
                },
                assert: (arrangeResult, actResult) =>
                {
                    Assert.AreEqual(typeof(Option<string>), actResult.GetType());
                }
            );
        }
    }
}