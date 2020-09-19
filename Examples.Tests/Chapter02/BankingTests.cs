using Examples.Chapter02.Banking;
using NUnit.Framework;
using System;

namespace Examples.Tests.Chapter02.Banking
{
    public sealed class BankingTests : TestFixture
    {
        /// <summary>
        /// A fake DateTime is provided to make test "pure" in that they do not rely on getting
        /// the DateTime from system (an I/O operation).
        /// </summary>
        static DateTime presentDate = new DateTime(2019, 12, 12, 12, 0, 0);

        [TestCase(+1, true)]
        [TestCase(0, true)]
        [TestCase(-1, false)]
        public void DateValidationTest(int offset, bool expectedResult)
        {
            Test(
                arrange: () => (
                    Transfer: new MakeTransfer { DateUtc = presentDate.AddSeconds(offset) },
                    Validator: new DateValidator(presentDate)
                ),
                act: arrangeResult => arrangeResult.Validator.IsValid(arrangeResult.Transfer),
                assert: (arrangeResult, actResult) => Assert.AreEqual(expectedResult, actResult, $"The time is {arrangeResult.Transfer.DateUtc}")
            );
        }

        [TestCase("ABCDEFG1234567", true)]
        [TestCase("XXXXXXXXXXXXXX", false)]
        public void BicValidationTest(string bic, bool expectedResult)
        {
            Test(
                arrange: () =>
                {
                    var validCodes = new[] { "ABCDEFG1234567" };
                    return (
                        Transfer: new MakeTransfer { Bic = bic },
                        Validator: new BicValidator(() => validCodes)
                    );
                },
                act: arrangeResult => arrangeResult.Validator.IsValid(arrangeResult.Transfer),
                assert: (arrangeResult, actResult) => Assert.AreEqual(expectedResult, actResult)
            );
        }
    }
}
