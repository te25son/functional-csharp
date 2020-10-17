using NUnit.Framework;
using System.Linq;
using Examples.Chapter05;

namespace Examples.Tests.Chapter05
{
    using static Enumerable;
    using static PopulationStatistics;

    public sealed class PopulationStatisticsTests : TestFixture
    {
        [TestCase(ExpectedResult = 75000)]
        public decimal AverageEarningsOfRichestQuartileTest() =>
            Test(
                arrange: _ => Range(1, 8)
                    .Select(i => new Person { Earnings = i * 10000 })
                    .ToList(),
                act: arrangedData => AverageEarningsOfRichestQuartile(arrangedData));
    }
}
