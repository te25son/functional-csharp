using Examples.Chapter05;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Tests.Chapter05
{
    public sealed class PersonEmailTests : TestFixture
    {
        [TestCase("Bilbo", "Baggins", ExpectedResult = "biba")]
        [TestCase("123", "456", ExpectedResult = "1245")]
        [TestCase("'!><", "#$%^", ExpectedResult = "'!#$")]
        public string CanAbbreviateName(string firstName, string lastName) =>
            Test(
                arrange: _ => new Person(firstName, lastName),
                act: arrangedData => PersonComponent.AbbreviateName(arrangedData));

        [TestCase("Bilbo", "Baggins", ExpectedResult = "biba@company.com")]
        [TestCase("123", "456", ExpectedResult = "1245@company.com")]
        [TestCase("'!><", "#$%^", ExpectedResult = "'!#$@company.com")]
        public string CanGetEmailFor(string firstName, string lastName) =>
            Test(
                arrange: _ => new Person(firstName, lastName),
                act: arrangedData => PersonComponent.EmailFor(arrangedData));
    }
}
