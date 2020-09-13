using Examples.Chapter01;
using System;
using System.Collections.Generic;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var examples = new Dictionary<string, Action>
            {
                ["MutationsShouldBeAvoided"] = Chapter01.MutationShouldBeAvoided.Run,
                ["HOF"] = Chapter01.HOF.Run,
                ["FunctionFactories"] = Chapter01.FunctionFactories.Run,
                ["LF_ParallelNaive"] = Chapter02.ListFormatter.Parallel.Naive.ListFormatter._main
            };

            foreach (var example in examples.Where(e => e.Key.Equals("LF_ParallelNaive")))
            {
                example.Value();
            }
        }
    }
}
