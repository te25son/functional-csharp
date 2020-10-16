using Examples.Chapter05;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Tests.Chapter05
{
    public sealed class PersonEmailTests : TestFixture
    {
        [Test]
        public void CanCreateAbbreviation()
        {
            Test(
                arrange: _ => new Person("Bilbo", "Baggins"),
                act: arrangedData => PersonComponent.AbbreviateName(arrangedData),
                assert: actData => Assert.AreEqual("biba", actData)
            );
        }
    }
}
