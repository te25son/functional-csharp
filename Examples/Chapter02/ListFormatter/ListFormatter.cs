using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Chapter02.ListFormatter
{
    using static Console;

    public static class ListFormatter
    {
        static int counter;

        static string PrependCounter(string s) => $"{++counter}. {s}";

        public static List<string> Format(List<string> list) =>
            list.Select(StringExtension.ToSentenceCase)
                .Select(PrependCounter)
                .ToList();

        public static void _main()
        {
            var shoppingList = new List<string> { "apples", "bread", "coffee", "milk" };

            ListFormatter
                .Format(shoppingList)
                .ForEach(WriteLine);
        }
    }
}
