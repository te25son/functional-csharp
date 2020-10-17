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
                    .Select(i =>
                    {
                        var person = new Person("Abby", "Brook");
                        person.Earnings = i * 10000;
                        return person;
                    })
                    .ToList(),
                act: arrangedData => AverageEarningsOfRichestQuartile(arrangedData));
    }
}
