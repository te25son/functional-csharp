using Examples.Chapter05;

namespace Examples.Tests.Chapter05
{
    public class PersonTestFixture : TestFixture
    {
        public Person CreatePerson(string firstName, string lastName) =>
            new Person { FirstName = firstName, LastName = lastName };
    }
}
