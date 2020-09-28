using Functional;
using System;

namespace Examples.Chapter04
{
    using static F;
    using static Console;

    public static class Map
    {
        public static void Run()
        {
            Func<string, string> greet = name => $"Hello, {name}";

            Option<string> _ = None;
            Option<string> optJohn = Some("John");

            WriteLine(_.Map(greet));
            WriteLine(optJohn.Map(greet));
        }
    }
}
