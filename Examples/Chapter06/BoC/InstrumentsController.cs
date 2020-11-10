using System;
using Microsoft.AspNetCore.Mvc;
using Functional;

namespace Examples.Chapter06.BoC
{
    public class InstrumentsController : Controller
    {
        Func<string, Option<InstrumentDetails>> getInstrumentDetails;

        public IActionResult GetInstrumentDetails(string ticker) =>
            getInstrumentDetails(ticker)
                .Match<IActionResult>(
                    none: NotFound,
                    some: Ok);
    }
}
