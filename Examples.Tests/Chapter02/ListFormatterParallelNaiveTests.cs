using Examples.Chapter02.ListFormatter;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Examples.Tests.Chapter02
{
    public class ListFormatterParallelNaiveTests : TestFixture
    {
        [Test]
        public void FormatterWorksOnSingletonList()
        {
            Test(
                arrange: () => (
                    Formatter: new ListFormatterParallelNaive(),
                    Input: new[] { "coffee beans" }
                ),
                act: arrangeResult => arrangeResult.Formatter.Format(arrangeResult.Input),
                assert: (arrangeResult, actResult) => Assert.AreEqual("1. Coffee beans", actResult[0])
            );
        }

        [Test]
        public void FormatterDoesNotWorkOnLongList()
        {
            Test(
                arrange: () =>
                {
                    var inputSize = 10000;
                    return (
                        Formatter: new ListFormatterParallelNaive(),
                        Input: Enumerable.Range(1, inputSize).Select(i => $"item-{i}"),
                        InputSize: inputSize
                    );
                },
                act: arrangeResult => arrangeResult.Formatter.Format(arrangeResult.Input),
                assert: (arrangeResult, actResult) => Assert.AreNotEqual("10000, item-10000", actResult[arrangeResult.InputSize - 1])
            );
        }
    }
}
