using System;

namespace Examples.Chapter02
{
    using static Console;

    public static class Purity
    {
        public static void Run()
        {
            // You can isolate the pure, computational parts of your program
            // from the I/O.
            WriteLine("Enter your name.");
            var name = ReadLine();
            WriteLine(GreetingFor(name));
        }

        public static string GreetingFor(string name) => $"Hello {name}";
    }
}
