using System;
using Functional;

namespace Exercises.Chapter03
{
    using static F;
    using static Console;

    public enum DayOfWeek
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }

    public static class Enum
    {
        public static Option<T> Parse<T>(this string s)
            where T : struct
        => System.Enum.TryParse(s, out T t) ? Some(t) : None;
    }

    public static class EnumExercise
    {
        public static void Run()
        {
            var shouldBeSome = Enum.Parse<DayOfWeek>("Friday");
            var shouldBeNone = Enum.Parse<DayOfWeek>("Freeday");

            shouldBeSome.Match(
                () => { WriteLine("FAIL: should be Some"); return Unit.Value; }, 
                (weekday) => { WriteLine($"PASS: the weekday is {weekday}"); return Unit.Value; }
            );

            shouldBeNone.Match(
                () => { WriteLine("PASS: value is None"); return Unit.Value; },
                (weekday) => { WriteLine($"FAIL: the weekday is {weekday}"); return Unit.Value; }
            );
        }
    }
}
