using Examples.Chapter02.Banking;
using NUnit.Framework;
using System;

namespace Examples.Tests.Chapter02.Banking
{
    public sealed class BankingTests : TestFixture
    {
        static DateTime presentDate = new DateTime(2019, 12, 12);

        /// <summary>
        /// A fake DateTime is provided to make test "pure" in that they do not rely on getting
        /// the DateTime from system (an I/O operation).
        /// </summary>
        private class FakeDateTimeService : IDateTimeService
        {
            public DateTime NowUtc => presentDate;
        }

        [Test]
        public void ValidationPasses_WhenTransferDateIsFuture()
        {
            Test(
                arrange: () => (
                    Transfer: new MakeTransfer { DateUtc = presentDate.AddYears(1) },
                    Validator: new DateValidator(new FakeDateTimeService())
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
                    Transfer: new MakeTransfer { DateUtc = presentDate },
                    Validator: new DateValidator(new FakeDateTimeService())
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
                    Transfer: new MakeTransfer { DateUtc = presentDate.AddYears(-1) },
                    Validator: new DateValidator(new FakeDateTimeService())
                ),
                act: arrangeResult => arrangeResult.Validator.IsValid(arrangeResult.Transfer),
                assert: (arrangeResult, actResult) => Assert.IsFalse(actResult)
            );
        }
    }
}
