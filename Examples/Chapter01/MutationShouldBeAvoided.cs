using System;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Chapter01
{
    using static Enumerable;
    using static Console;

    public class MutationShouldBeAvoided
    {
        public static void Run()
        {
            WithListItBreaks();
            WithIEnumerableItWorks();
        }

        public static void WithListItBreaks()
        {
            var nums = Range(-10000, 20001).Reverse().ToList();

            Action task1 = () => WriteLine(nums.Sum());
            Action task2 = () => { nums.Sort(); WriteLine(nums.Sum()); };

            // By sorting the list while concurrently summing up the elements within the same list,
            // errors will inevitably occur (counting the same element more than once).
            Parallel.Invoke(task1, task2);
        }

        public static void WithIEnumerableItWorks()
        {
            var nums = Range(-10000, 20001).Reverse();

            Action task1 = () => WriteLine(nums.Sum());
            Action task2 = () => { nums.OrderBy(x => x); WriteLine(nums.Sum()); };

            // Unlike Sort, LINQs OrderBy does not mutate the original list. Instead, it creates
            // a new, modified version of the original list. That way task1 is summing up the elements
            // of the original list while task2 generates a new ordered list from the original list.
            Parallel.Invoke(task1, task2);
        }
    }
}
