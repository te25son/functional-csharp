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

        [TestCase(+1, true)]
        [TestCase(0, true)]
        [TestCase(-1, false)]
        public void ValidationPasses_WhenTransferDateIsFuture(int offset, bool expectedResult)
        {
            Test(
                arrange: () => (
                    Transfer: new MakeTransfer { DateUtc = presentDate.AddYears(offset) },
                    Validator: new DateValidator(new FakeDateTimeService())
                ),
                act: arrangeResult => arrangeResult.Validator.IsValid(arrangeResult.Transfer),
                assert: (arrangeResult, actResult) => Assert.AreEqual(expectedResult, actResult)
            );
        }
    }
}
