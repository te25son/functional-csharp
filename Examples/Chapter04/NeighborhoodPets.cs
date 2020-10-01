using System;
using System.Collections.Generic;
using Functional;

namespace Examples.Chapter04
{
    using static Console;

    public static class NeighborhoodPets
    {
        public static void Run()
        {
            var neighbors = new[]
            {
                new { Name = "Jimmy", Pets = new Pet[] { "Fluffy", "Spot" }},
                new { Name = "Caroline", Pets = new Pet[] {}},
                new { Name = "Billy", Pets = new Pet[] { "Sir Sparkles" }}
            };

            IEnumerable<IEnumerable<Pet>> nested = neighbors.Map(n => n.Pets);
            IEnumerable<Pet> flat = neighbors.Bind(n => n.Pets);

            nested.ForEach(WriteLine);
            flat.ForEach(WriteLine);
        }
    }

    public class Neighbor
    {
        public string Name { get; set; }

        public IEnumerable<Pet> Pets { get; set; } = new Pet[] { };
    }

    public class Pet
    {
        private readonly string _name;

        private Pet(string name)
        {
            _name = name;
        }

        public static implicit operator Pet(string name) => new Pet(name);
    }
}
