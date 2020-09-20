using System;

namespace Exercises.Chapter02.BmiCalculator
{
    using static Console;
    using static Math;

    public static class BmiCalculator
    {
        public static void Run()
        {
            Run(Read, Write);
        }

        internal static void Run(Func<string, double> read, Action<BmiRange> write)
        {
            double weight = read("weight"),
                   height = read("height");

            var bmiRange = CalculateBmi(height, weight).ToBmiRange();

            write(bmiRange);
        }

        internal static double CalculateBmi(double height, double weight) =>
            Round(weight / Pow(height, 2), 2);

        internal static BmiRange ToBmiRange(this double bmi) =>
            bmi < 18.5 ? BmiRange.Underweight
                : 25 <= bmi && bmi < 30 ? BmiRange.Overweight
                    : 30 <= bmi ? BmiRange.Obese
                        : BmiRange.Healthy;

        private static double Read(string field)
        {
            WriteLine($"Please enter your {field}");
            return double.Parse(ReadLine());
        }

        private static void Write(BmiRange bmiRange) =>
            WriteLine($"Based on your BMI, you are {bmiRange}");
    }       
}
