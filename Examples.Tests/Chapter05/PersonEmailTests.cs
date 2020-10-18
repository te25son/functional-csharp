using Examples.Chapter05;
using Functional;
using NUnit.Framework;
using System.Linq;

namespace Examples.Tests.Chapter05
{
    using static F;
    using static PersonComponent_FuncComp;

    public sealed class PersonEmailTests_Regular : PersonTestFixture
    {
        [TestCase("Bilbo", "Baggins", ExpectedResult = "biba")]
        [TestCase("123", "456", ExpectedResult = "1245")]
        [TestCase("'!><", "#$%^", ExpectedResult = "'!#$")]
        public string CanAbbreviateName_UsingFunctionComposition(string firstName, string lastName) =>
            Test(
                arrange: _ => CreatePerson(firstName, lastName),
                act: arrangedData => AbbreviateName(arrangedData));

        [TestCase("Bilbo", "Baggins", ExpectedResult = "biba@company.com")]
        [TestCase("123", "456", ExpectedResult = "1245@company.com")]
        [TestCase("'!><", "#$%^", ExpectedResult = "'!#$@company.com")]
        public string CanGetEmailFor_UsingFunctionComposition(string firstName, string lastName) =>
            Test(
                arrange: _ => CreatePerson(firstName, lastName),
                act: arrangedData => EmailFor(arrangedData));

        [TestCase("Bilbo", "Baggins", ExpectedResult = "biba")]
        [TestCase("123", "456", ExpectedResult = "1245")]
        [TestCase("'!><", "#$%^", ExpectedResult = "'!#$")]
        public string CanAbbreviateName_UsingMethodChaining(string firstName, string lastName) =>
            Test(
                arrange: _ => CreatePerson(firstName, lastName),
                act: arrangedData => arrangedData.AbbreviateName());

        [TestCase("Bilbo", "Baggins", ExpectedResult = "biba@company.com")]
        [TestCase("123", "456", ExpectedResult = "1245@company.com")]
        [TestCase("'!><", "#$%^", ExpectedResult = "'!#$@company.com")]
        public string CanGetEmailFor_UsingMethodChaining(string firstName, string lastName) =>
            Test(
                arrange: _ => CreatePerson(firstName, lastName),
                act: arrangedData => arrangedData.AbbreviateName().AppendDomain());
    }

    public sealed class PersonEmailTests_Elevated : PersonTestFixture
    {
        [TestCase("Bilbo", "Baggins", ExpectedResult = "biba")]
        [TestCase("123", "456", ExpectedResult = "1245")]
        [TestCase("'!><", "#$%^", ExpectedResult = "'!#$")]
        public string CanAbbreviateName_UsingFunctionComposition(string firstName, string lastName) =>
            Test(
                arrange: _ => Some(CreatePerson(firstName, lastName)),
                act: arrangedData => arrangedData.Map(AbbreviateName)).ToString();

        [TestCase("Bilbo", "Baggins", ExpectedResult = "biba@company.com")]
        [TestCase("123", "456", ExpectedResult = "1245@company.com")]
        [TestCase("'!><", "#$%^", ExpectedResult = "'!#$@company.com")]
        public string CanGetEmailFor_UsingFunctionComposition(string firstName, string lastName) =>
            Test(
                arrange: _ => Some(CreatePerson(firstName, lastName)),
                act: arrangedData => arrangedData.Map(EmailFor)).ToString();

        [TestCase("Bilbo", "Baggins", ExpectedResult = "biba")]
        [TestCase("123", "456", ExpectedResult = "1245")]
        [TestCase("'!><", "#$%^", ExpectedResult = "'!#$")]
        public string CanAbbreviateName_UsingMethodChaining(string firstName, string lastName) =>
            Test(
                arrange: _ => Some(CreatePerson(firstName, lastName)),
                act: arrangedData => arrangedData.Map(AbbreviateName).ToString());

        [TestCase("Bilbo", "Baggins", ExpectedResult = "biba@company.com")]
        [TestCase("123", "456", ExpectedResult = "1245@company.com")]
        [TestCase("'!><", "#$%^", ExpectedResult = "'!#$@company.com")]
        public string CanGetEmailFor_UsingMethodChaining(string firstName, string lastName) =>
            Test(
                arrange: _ => Some(CreatePerson(firstName, lastName)),
                act: arrangedData => arrangedData.Map(AbbreviateName).Map(AppendDomain).ToString());
    }
}
