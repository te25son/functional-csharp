using System;
using Functional;

namespace Examples.Chapter04
{
    using static F;
    using static Console;

    public static class ForEachExample
    {
        public static void Run()
        {
            var name = Some("Harry");

            // In both cases below I separate the logic (MAP) from the
            // side-effects (FOREACH)
            name.Map(name => $"Hello, {name}").ForEach(WriteLine);
            name.Map(name => name.ToUpper()).ForEach(WriteLine);

            var names = new[] { "Jack", "Jill" };
            names.Map(name => $"Goodby, {name}").ForEach(WriteLine);
            names.Map(name => name.ToUpper()).ForEach(WriteLine);
        }
    }
}
