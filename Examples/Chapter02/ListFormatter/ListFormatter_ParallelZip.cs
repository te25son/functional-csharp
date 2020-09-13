using System.Collections.Generic;
using System.Linq;

namespace Examples.Chapter02.ListFormatter.Parallel.Zip
{
    public static class ListFormatter
    {
        public static List<string> Format(List<string> list) =>
            list.AsParallel()
                .Select(StringExtension.ToSentenceCase)
                .Zip(ParallelEnumerable.Range(1, list.Count), (s, i) => $"{i}. {s}")
                .ToList();
    }
}
