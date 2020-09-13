using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examples.Chapter02.ListFormatter
{
    using static Console;

    class ListFormatterParallelNaive
    {
        int counter;

        Numbered<T> ToNumberedValue<T>(T t) => new Numbered<T>(t, ++counter);

        public List<string> Format(IEnumerable<string> list) =>
            list.AsParallel()
                .Select(StringExtension.ToSentenceCase)
                .Select(ToNumberedValue)
                .OrderBy(n => n.Number)
                .Select(s => s.ToString())
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
