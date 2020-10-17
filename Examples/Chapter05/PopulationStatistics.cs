using System.Collections.Generic;
using System.Linq;

namespace Examples.Chapter05
{
    public static class PopulationStatistics
    {
        public static decimal AverageEarningsOfRichestQuartile(List<Person> population) =>
            population
                .OrderByDescending(p => p.Earnings)
                .Take(population.Count() / 4)
                .Select(p => p.Earnings)
                .Average();
    }
}
