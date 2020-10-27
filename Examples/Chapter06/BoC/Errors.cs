using Functional;

namespace Examples.Chapter06.BoC
{
    public static class Errors
    {
        public static InvalidBic InvalidBic => new InvalidBic();

        public static TransferDateIsPast TransferDateIsPast => new TransferDateIsPast();
    }

    public sealed class InvalidBic : Error
    {
        public override string Message { get; }
            = "The beneficiary's BIC/Swift code is invalid";
    }

    public sealed class TransferDateIsPast : Error
    {
        public override string Message { get; }
            = "Transfer date cannot be in the past";
    }
}
