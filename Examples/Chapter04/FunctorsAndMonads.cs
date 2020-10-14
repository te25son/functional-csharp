using Functional;
using System;
using System.Collections.Generic;

namespace Examples.Chapter04
{
    using static CoreEnumerable;
    using static Console;

    public class Students
    {
        public int Id { get; set; }

        public IEnumerable<string> FavoriteColors { get; set; }

        public Students(int id, IEnumerable<string> favoriteColors)
        {
            Id = id;
            FavoriteColors = favoriteColors;
        }
    }

    public static class FunctorsAndMonads
    {
        public static void Run()
        {
            var students = new[]
            {
                new Students(1, new[] { "Red", "Green", "Purple" }),
                new Students(2, new[] { "Yellow", "Pink", "Orange" }),
                new Students(3, new[] { "Red", "Blue" })
            };

            students.Bind(s => s.FavoriteColors).ForEach(WriteLine);
            students.Bind(s => List(s.Id)).ForEach(WriteLine);
            students.Map(s => s.Id).ForEach(WriteLine);
            students.Map(s => s.FavoriteColors).ForEach(WriteLine);
        }
    }
}
