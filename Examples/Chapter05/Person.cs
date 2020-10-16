using System;

namespace Examples.Chapter05
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public class PersonComponent
    {
        public Func<Person, string> EmailFor = p => AppendDomain(AbbreviateName(p));

        static string AbbreviateName(Person person) =>
            Abbreviate(person.FirstName) + Abbreviate(person.LastName);

        static string AppendDomain(string localPart) =>
            $"{localPart}@company.com";

        static string Abbreviate(string s) =>
            s.Substring(0, 2).ToLower();
    }
}
