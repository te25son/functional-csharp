using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Examples.Chapter02.ListFormatter
{
    using static Console;

    public class ListFormatterParallelNaive
    {
        int counter;

        Numbered<T> ToNumberedValue<T>(T t) => new Numbered<T>(t, ++counter);

        string Render(Numbered<string> s) => $"{s.Number}. {s.Value}";

        public List<string> Format(IEnumerable<string> list) =>
            list.AsParallel()
                .Select(StringExtension.ToSentenceCase)
                .Select(ToNumberedValue)
                .OrderBy(n => n.Number)
                .Select(Render)
                .ToList();

        public static void _main()
        {
            var size = 100000;
            var shoppingList = Enumerable.Range(1, size).Select(i => $"item{i}");

            new ListFormatterParallelNaive()
                .Format(shoppingList)
                .ForEach(WriteLine);
        }
    }
}
