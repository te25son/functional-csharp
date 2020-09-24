using Functional;

namespace Examples.Chapter03
{
    using static F;
    using static System.Console;

    public static class OptionPlay
    {
        public static void Run()
        {
            WriteLine(Greet(None));
            WriteLine(Greet(Some("John")));
        }

        public static string Greet(Option<string> greetee) =>
            greetee.Match(
                none: () => "Sorry, who?",
                some: (name) => $"Hello, {name}");
    }
}
