using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Chapter02.ListFormatter
{
    using static Console;

    public class ListFormatter
    {
        int counter;

        string PrependCounter(string s) => $"{++counter}. {s}";

        public  List<string> Format(List<string> list) =>
            list.Select(StringExtension.ToSentenceCase)
                .Select(PrependCounter)
                .ToList();

        public static void _main()
        {
            var shoppingList = new List<string> { "apples", "bread", "coffee", "milk" };
            var formatter = new ListFormatter();

            formatter
                .Format(shoppingList)
                .ForEach(WriteLine);
        }
    }
}
