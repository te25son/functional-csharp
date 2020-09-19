using Examples.Chapter02.Banking;
using NUnit.Framework;
using System;

namespace Examples.Tests.Chapter02
{
    public sealed class BankingTests : TestFixture
    {
        [Test]
        public void ValidationPasses_WhenTransferDateIsFuture()
        {
            Test(
                arrange: () => (
                    Transfer: new MakeTransfer { DateUtc = DateTime.UtcNow.AddYears(1) },
                    Validator: new DateValidator()
                ),
                act: arrangeResult => arrangeResult.Validator.IsValid(arrangeResult.Transfer),
                assert: (arrangeResult, actResult) => Assert.IsTrue(actResult)
            );
        }

        [Test]
        public void ValidationPasses_WhenTransferDateIsNow()
        {
            Test(
                arrange: () => (
                    Transfer: new MakeTransfer { DateUtc = DateTime.UtcNow },
                    Validator: new DateValidator()
                ),
                act: arrangeResult => arrangeResult.Validator.IsValid(arrangeResult.Transfer),
                assert: (arrangeResult, actResult) => Assert.IsTrue(actResult)
            );
        }

        [Test]
        public void ValidationFails_WhenTransferDateIsPast()
        {
            Test(
                arrange: () => (
                    Transfer: new MakeTransfer { DateUtc = DateTime.UtcNow.AddYears(-1) },
                    Validator: new DateValidator()
                ),
                act: arrangeResult => arrangeResult.Validator.IsValid(arrangeResult.Transfer),
                assert: (arrangeResult, actResult) => Assert.IsFalse(actResult)
            );
        }
    }
}
