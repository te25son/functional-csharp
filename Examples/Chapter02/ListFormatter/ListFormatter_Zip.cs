using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Chapter02.ListFormatter.Zip
{
    public static class ListFormatter
    {
        public static List<string> Format(List<string> list) =>
            list
                .Select(StringExtension.ToSentenceCase)
                .Zip(Enumerable.Range(1, list.Count), (s, i) => $"{i}. {s}")
                .ToList()
    }
}
