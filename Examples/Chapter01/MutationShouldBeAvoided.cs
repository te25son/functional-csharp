using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Chapter01
{
    using static Enumerable;
    using static Console;

    public class MutationShouldBeAvoided
    {
        public static void WithListItBreaks()
        {
            var nums = Range(-10000, 20001).Reverse().ToList();

            Action task1 = () => WriteLine(nums.Sum());
            Action task2 = () => { nums.Sort(); WriteLine(nums.Sum()); };

            Parallel.Invoke(task1, task2);
        }

        public static void WithIEnumerableItWorks()
        {
            var nums = Range(-10000, 20001).Reverse();

            Action task1 = () => WriteLine(nums.Sum());
            Action task2 = () => { nums.OrderBy(x => x); WriteLine(nums.Sum()); };

            Parallel.Invoke(task1, task2);
        }
    }
}
