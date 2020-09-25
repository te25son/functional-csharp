using Functional;
using System;
using System.Collections.Generic;

namespace Exercises.Chapter03
{
    using static F;
    using static Console;

    public static class LookupExercise
    {
        public static Option<T> Lookup<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            foreach (var item in enumerable)
                if (predicate(item))
                    return Some(item);
            return None;
        }
            
        public static void Run()
        {
            bool isOdd(int i) => i % 2 == 1;

            WriteLine(new List<int>().Lookup(isOdd).Match(() => "Pass", (i) => "Fail"));
            WriteLine(new List<int> { 1 }.Lookup(isOdd).Match(() => "Fail", (i) => "Pass"));
        }
    }
}
