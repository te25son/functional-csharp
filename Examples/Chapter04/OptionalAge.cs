using System;
using Examples.Chapter03;
using Functional;

namespace Examples.Chapter04
{
    using static Console;

    public static class AskForValidAgeAndPrintFlatteringMessage
    {
        public static void Main() =>
            WriteLine($"Only {ReadAge()}!? That's young!");

        // Recursively calls itself while parsing the inputed age fails.
        static Age ReadAge() =>
            ParseAge(Prompt("Please enter your age.")).Match(
                () => ReadAge(),
                (age) => age);

        // Parses an age from an int and tries to make an age from the given int.
        static Option<Age> ParseAge(string s) =>
            Int.Parse(s).Bind(Age.Of);

        static string Prompt(string prompt)
        {
            WriteLine(prompt);
            return ReadLine();
        }
    }
}
