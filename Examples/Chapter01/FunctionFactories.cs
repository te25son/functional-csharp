using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chapter01
{
    using static Console;
    using static System.Linq.Enumerable;

    public class FunctionFactories
    {
        public static Func<int, bool> isMod(int n) => i => i % n == 0;

        internal static void Run()
        {
            var isDivisibleBy2 = Range(1, 20).Where(isMod(2));
            var isDivisibleBy3 = Range(1, 20).Where(isMod(3));

            isDivisibleBy2.WriteEach();
            isDivisibleBy3.WriteEach();
        }
    }
}
