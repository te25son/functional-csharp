using System;
using Functional;

namespace Examples.Chapter04
{
    using static Console;

    public static class NaturalFilter
    {
        public static void Run()
        {
            WriteLine(new Natural("2").ToNatural());
            WriteLine(new Natural("-2").ToNatural());
            WriteLine(new Natural("0").ToNatural());
        }
    }

    public class Natural
    {
        private readonly string _value;

        public Natural(string value)
        {
            _value = value;
        }

        private bool IsNatural(int i) => i >= 0;

        public Option<int> ToNatural() => Int.Parse(_value).Where(IsNatural);
    }
}
