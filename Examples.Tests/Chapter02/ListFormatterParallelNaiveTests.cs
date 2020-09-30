using Examples.Chapter02.ListFormatter.Parallel.Naive;
using NUnit.Framework;
using System.Linq;

namespace Examples.Tests.Chapter02
{
    public class ListFormatterParallelNaiveTests : TestFixture
    {
        [Test]
        public void FormatterWorksOnSingletonList()
        {
            Test(
                arrange: _ => (
                    Formatter: new ListFormatter(),
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
                arrange: _ =>
                {
                    var inputSize = 10000;
                    return (
                        Formatter: new ListFormatter(),
                        Input: Enumerable.Range(1, inputSize).Select(i => $"item-{i}"),
                        InputSize: inputSize
                    );
                },
                act: arrangeResult => arrangeResult.Formatter.Format(arrangeResult.Input),
                assert: (arrangeResult, actResult) => Assert.AreNotEqual("10000, Item-10000", actResult[arrangeResult.InputSize - 1])
            );
        }
    }
}
