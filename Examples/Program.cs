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
                ["MutationsShouldBeAvoided"] = Chapter01.MutationShouldBeAvoided.Run
            };

            foreach (var example in examples)
            {
                example.Value();
            }
        }
    }
}
