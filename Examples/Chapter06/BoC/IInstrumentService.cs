using Functional;

namespace Examples.Chapter06.BoC
{
    public interface IInstrumentService
    {
        Option<InstrumentDetails> GetInstrumentDetails(string ticker);
    }
}
