using Examples.Chapter02.ListFormatter;
using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Examples.Tests.Chapter02
{
    public class ListFormatterTests : TestFixture
    {
        [Test]
        public void FormatterWorksOnSingletonList()
        {
            Test(
                () => (
                    Formatter: new ListFormatter(),
                    Input: new List<string> { "coffee beans" }
                ),
                arrangeResult => arrangeResult.Formatter.Format(arrangeResult.Input),
                (arrangeResult, actResult) => Assert.AreEqual("1. Coffee beans", actResult[0])
            );
        }

        [Test]
        public void FormatterWorksOnListWithMoreThanOneItem()
        {
            Test(
                () => (
                    Formatter: new ListFormatter(),
                    Input: new List<string> { "coffee beans", "APPLES" }
                ),
                arrangeResult => arrangeResult.Formatter.Format(arrangeResult.Input),
                (arrangeResult, actResult) =>
                {
                    Assert.AreEqual("1. Coffee beans", actResult[0]);
                    Assert.AreEqual("2. Apples", actResult[1]);
                }
            );
        }
    }
}
