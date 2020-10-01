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
                ["LF_ParallelNaive"] = Chapter02.ListFormatter.Parallel.Naive.ListFormatter._main,
                ["OptionPlay"] = Chapter03.OptionPlay.Run,
                ["Map"] = Chapter04.Map.Run,
                ["ApplePie"] = Chapter04.ApplePieExample.Run,
                ["ForEachEx"] = Chapter04.ForEachExample.Run,
                ["Pets"] = Chapter04.NeighborhoodPets.Run
            };

            foreach (var example in examples.Where(e => e.Key.Equals("Pets")))
            {
                example.Value();
            }
        }
    }
}
