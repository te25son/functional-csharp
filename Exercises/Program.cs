using System;
using System.Collections.Generic;
using Exercises.Chapter01;

namespace Exercises
{
    using static Console;

    class Program
    {
        static void Main(string[] args)
        {
            var hobbits = new List<string>
            {
                "Frodo", "Samwise", "Bilbo", "Merry", "Pippin"
            };

            var hobbitsByNameLength = hobbits.QuickSort((x, y) => x.Length.CompareTo(y.Length));

            foreach (var hobbit in hobbitsByNameLength)
                WriteLine(hobbit);
        }
    }
}
