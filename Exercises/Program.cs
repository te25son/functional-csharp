using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var exercises = new Dictionary<string, Action>
            {
                ["BmiCalc"] = Chapter02.BmiCalculator.BmiCalculator.Run,
                ["EnumExr"] = Chapter03.EnumExercise.Run
            };

            foreach (var exercise in exercises.Where(e => e.Key.Equals("EnumExr")))
            {
                exercise.Value();
            }
        }
    }
}
