using System;
using Functional;

namespace Examples.Chapter04
{
    using static F;
    using static Console;

    public class Apple
    {
    }

    public class ApplePie
    {
        public ApplePie(Apple apple)
        {
        }
    }

    public static class ApplePieExample
    {
        public static void Run()
        {
            Func<Apple, ApplePie> makePie = apple => new ApplePie(apple);

            Option<Apple> basketFull = Some(new Apple());
            Option<Apple> basketEmpty = None;

            WriteLine(basketFull.Map(makePie).Match(() => "Nothing in the basket.", pie => "Your grandma made a pie."));
            WriteLine(basketEmpty.Map(makePie).Match(() => "Nothing in the basket.", pie => "Your grandma made a pie."));
        }
    }
}
