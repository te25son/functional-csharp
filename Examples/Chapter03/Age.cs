using Functional;
using Functional.Option;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chapter03
{
    using static F;

    public enum Risk { Low, Medium, High}

    public struct Age
    {
        private int Value { get; }

        public static Option<Age> Of(int age) =>
            IsValid(age) ? Some(new Age(age)) : None;

        public static bool operator < (Age l, Age r) =>
            l.Value < r.Value;
        public static bool operator > (Age l, Age r) =>
            l.Value > r.Value;

        public static bool operator < (Age l, int r) =>
            l < new Age(r);
        public static bool operator > (Age l, int r) =>
            l > new Age(r);

        private Age(int value)
        {
            if (!IsValid(value))
                throw new ArgumentException($"{value} is not a valid age.");

            Value = value;
        }

        private static bool IsValid(int age) =>
            0 <= age && age < 120;
    }
}
