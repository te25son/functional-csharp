using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Chapter05
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Earnings { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    /// <summary>
    /// Example using functional composition
    /// </summary>
    public static class PersonComponent_FuncComp
    {
        public static Func<Person, string> EmailFor = p => AppendDomain(AbbreviateName(p));

        public static string AbbreviateName(Person person) =>
            Abbreviate(person.FirstName) + Abbreviate(person.LastName);

        public static string AppendDomain(string localPart) =>
            $"{localPart}@company.com";

        public static string Abbreviate(string s) =>
            s.Substring(0, 2).ToLower();

        public static decimal AverageEarningsOfRichestQuartile(List<Person> population) =>
            population
                .OrderByDescending(p => p.Earnings)
                .Take(population.Count() / 4)
                .Select(p => p.Earnings)
                .Average();
    }


    /// <summary>
    /// Example using method chaining
    /// </summary>
    public static class PersonComponent_MethodChain
    {
        public static string AbbreviateName(this Person person) =>
            Abbreviate(person.FirstName) + Abbreviate(person.LastName);

        public static string AppendDomain(this string localPart) =>
            $"{localPart}@company.com";

        public static string Abbreviate(string s) =>
            s.Substring(0, 2).ToLower();
    }
}
