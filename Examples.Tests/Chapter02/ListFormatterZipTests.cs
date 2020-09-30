using Examples.Chapter02.ListFormatter.Zip;
using Examples.Chapter02.ListFormatter.Parallel.Zip;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Tests.Chapter02
{
    public class ListFormatterZipTests : TestFixture
    {
        [TestCase(true)]
        [TestCase(false)]
        public void FormatterForcesUpperCaseOfFirstLetter(bool useParallel)
        {
            Test(
                arrange: _ => new List<string> { "banana", "apple", "123" },
                act: arrangeResult => Format(arrangeResult, useParallel),
                assert: (arrangeResult, actResult) =>
                {
                    Assert.AreEqual("1. Banana", actResult[0]);
                    Assert.AreEqual("2. Apple", actResult[1]);
                    Assert.AreEqual("3. 123", actResult[2]);
                }
            );
        }

        [TestCase(true)]
        [TestCase(false)]
        public void FormatterWorksOnSingletonList(bool useParallel)
        {
            Test(
                arrange: _ => new List<string> { "coffee beans" },
                act: arrangeResult => Format(arrangeResult, useParallel),
                assert: (arrangeResult, actResult) => Assert.AreEqual("1. Coffee beans", actResult[0])
            );
        }

        [TestCase(true)]
        [TestCase(false)]
        public void FormatterWorksOnLargerLists(bool useParallel)
        {
            Test(
                arrange: _ =>
                {
                    var inputSize = 10000;
                    return (
                        Input: Enumerable.Range(1, inputSize).Select(i => $"item-{i}").ToList(),
                        InputSize: inputSize
                    );
                },
                act: arrangeResult => Format(arrangeResult.Input, useParallel),
                assert: (arrangeResult, actResult) => Assert.AreEqual("10000. Item-10000", actResult[arrangeResult.InputSize - 1])
            );
        }

        private List<string> Format(List<string> list, bool parallelize)
        {
            return parallelize
                ? Examples.Chapter02.ListFormatter.Parallel.Zip.ListFormatter.Format(list)
                : Examples.Chapter02.ListFormatter.Zip.ListFormatter.Format(list);
        }
    }
}
