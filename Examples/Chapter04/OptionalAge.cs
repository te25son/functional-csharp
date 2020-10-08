using System;
using System.Collections.Generic;
using Examples.Chapter03;
using Functional;

namespace Examples.Chapter04
{
    using static Console;

    public static class AskForValidAgeAndPrintFlatteringMessage
    {
        public static void _main() =>
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

    public static class SurveryOptionalAge
    {
        static IEnumerable<Subject> Population => new[]
        {
            new Subject { Age = Age.Of(33) },
            new Subject { },
            new Subject { Age = Age.Of(37) }
        };
    }

    class Subject
    {
        public Option<Age> Age { get; set; }
    }
}
