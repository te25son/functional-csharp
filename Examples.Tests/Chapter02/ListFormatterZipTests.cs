using Examples.Chapter02.ListFormatter.Zip;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Tests.Chapter02
{
    public class ListFormatterZipTests : TestFixture
    {
        [Test]
        public void FormatterForcesUpperCaseOfFirstLetter()
        {
            Test(
                arrange: () => new List<string> { "banana", "apple", "123" },
                act: arrangeResult => ListFormatter.Format(arrangeResult),
                assert: (arrangeResult, actResult) =>
                {
                    Assert.AreEqual("1. Banana", actResult[0]);
                    Assert.AreEqual("2. Apple", actResult[1]);
                    Assert.AreEqual("3. 123", actResult[2]);
                }
            );
        }

        [Test]
        public void FormatterWorksOnSingletonList()
        {
            Test(
                arrange: () => new List<string> { "coffee beans" },
                act: arrangeResult => ListFormatter.Format(arrangeResult),
                (arrangeResult, actResult) => Assert.AreEqual("1. Coffee beans", actResult[0])
            );
        }

        [Test]
        public void FormatterWorksOnLargerLists()
        {
            Test(
                arrange: () =>
                {
                    var inputSize = 10000;
                    return (
                        Input: Enumerable.Range(1, inputSize).Select(i => $"item-{i}").ToList(),
                        InputSize: inputSize
                    );
                },
                act: arrangeResult => ListFormatter.Format(arrangeResult.Input),
                assert: (arrangeResult, actResult) => Assert.AreEqual("10000. Item-10000", actResult[arrangeResult.InputSize - 1])
            );
        }
    }
}
