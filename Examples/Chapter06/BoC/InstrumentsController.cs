using System;
using Microsoft.AspNetCore.Mvc;
using Functional;
using System.Web.Mvc;

namespace Examples.Chapter06.BoC
{
    public class InstrumentsController : Controller
    {
        Func<string, Option<InstrumentDetails>> getInstrumentDetails;

        public IActionResult GetInstrumentDetails(string ticker) =>
            getInstrumentDetails(ticker)
                .Match<IActionResult>(
                    NotFound,
                    Ok);

        private Func<InstrumentDetails, IActionResult> Ok(object result)
        {
            throw new NotImplementedException();
        }

        private Func<IActionResult> NotFound()
        {
            throw new NotImplementedException();
        }
    }
}