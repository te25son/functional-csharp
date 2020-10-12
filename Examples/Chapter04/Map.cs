using Functional;
using System;

namespace Examples.Chapter04
{
    using static F;
    using static Console;

    public static class Map
    {
        public static void ListMap()
        {
            Func<int, int> plus3 = x => x + 3;

            var list = new[] { 1, 2, 3 };
            var listPlus3 = list.Map(plus3);

            list.ForEach(WriteLine);
            listPlus3.ForEach(WriteLine);
        }

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
