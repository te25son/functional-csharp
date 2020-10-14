using Examples.Tests;
using Functional.Option;
using NUnit.Framework;
using System;
using System.Linq;

namespace Functional.Tests.Core
{
    using static F;

    public class CoreTests : TestFixture
    {
        [TestCase("John", "Some")]
        [TestCase(null, "None")]
        public void MapReturnsCorrectType(string name, string expectedOutput)
        {
            Test(
                arrange: _ => CreateSimpleOption(name),
                act: arrangeResult => arrangeResult.Map(Greet),
                assert: (arrangeResult, actResult) => Assert.AreEqual(expectedOutput, actResult.ToString())
            );
        }

        private Option<T> CreateSimpleOption<T>(T t) =>
            t != null ? Some(t) : None;

        private string Greet(string greeteeName) => $"Hello, {greeteeName}";
    }
}