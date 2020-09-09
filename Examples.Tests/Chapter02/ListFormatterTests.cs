using Examples.Chapter02.ListFormatter;
using NUnit.Framework;
using System.Collections.Generic;

namespace Examples.Tests.Chapter02
{
    public class ListFormatterTests
    {
        [Test]
        public void FormatWorksOnSingletonList()
        {
            var input = new List<string> { "coffee beans" };
            var output = ListFormatter.Format(input);
            Assert.AreEqual("1. Coffee beans", output[0]);
        }
    }
}
