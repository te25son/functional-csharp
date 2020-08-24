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
            };

            foreach (var example in examples.Where(e => e.Key.Equals("FunctionFactories")))
            {
                example.Value();
            }
        }
    }
}
