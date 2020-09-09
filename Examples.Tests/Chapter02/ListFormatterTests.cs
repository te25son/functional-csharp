using Examples.Chapter02.ListFormatter;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Examples.Tests.Chapter02
{
    public class ListFormatterTests : TestFixture
    {
        [Test]
        public void FormatterWorksOnSingletonList()
        {
            Test(
                () => new List<string> { "coffee beans" },
                (formatter, singletonList) => formatter.Format(singletonList),
                formattedList => Assert.AreEqual("1. Coffee beans", formattedList[0])
            );
        }

        [Test]
        public void FormatterWorksOnListWithMoreThanOneItem()
        {
            Test(
                () => new List<string> { "coffee beans", "APPLES" },
                (formatter, multiItemList) => formatter.Format(multiItemList),
                formattedList =>
                {
                    Assert.AreEqual("1. Coffee beans", formattedList[0]);
                    Assert.AreEqual("2. Apples", formattedList[1]);
                }
            );
        }
    }
}
