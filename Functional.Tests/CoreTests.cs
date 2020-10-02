using Examples.Tests;
using Functional.Option;
using NUnit.Framework;
using System;

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
                arrange: _ => name == null ? None : Some(name),
                act: arrangeResult => arrangeResult.Map(Greet),
                assert: (arrangeResult, actResult) => Assert.AreEqual(expectedOutput, actResult.ToString())
            );
        }

        public string Greet(string greeteeName) => $"Hello, {greeteeName}";
    }
}