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

    public static class PopulationStatistics_Split
    {
        /// <summary>
        /// Splitting the function makes it more readable.
        /// </summary>
        public static decimal AverageEarningsOfRichestQuartile_Split(List<Person> population) =>
            population
                .RichestQuartile()
                .AverageEarnings();

        public static decimal AverageEarnings(this IEnumerable<Person> population) =>
            population.Average(p => p.Earnings);

        public static IEnumerable<Person> RichestQuartile(this List<Person> population) =>
            population.OrderByDescending(p => p.Earnings).Take(population.Count() / 4);
    }
}
