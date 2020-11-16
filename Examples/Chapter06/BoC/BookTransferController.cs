using Functional;
using Functional.Either;
using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Chapter06.BoC
{
    using static F;

    public class BookTransferController : Controller
    {
        DateTime now;

        Regex bicRegex = new Regex("[A-Z]{11}");

        public ResultDto<Unit> BookTransfer(BookTransfer cmd) =>
            Handle(cmd).ToResult();

        Either<Error, Unit> Handle(BookTransfer cmd) =>
            Right(cmd)
                .Bind(ValidateBic)
                .Bind(ValidateDate)
                .Bind(Save);

        Either<Error, BookTransfer> ValidateBic(BookTransfer cmd)
        {
            if (!bicRegex.IsMatch(cmd.Bic))
                return Errors.InvalidBic;

            else return cmd;
        }

        Either<Error, BookTransfer> ValidateDate(BookTransfer cmd)
        {
            if (cmd.DateUtc.Date <= now.Date)
                return Errors.TransferDateIsPast;

            else return cmd;
        }

        Either<Error, Unit> Save(BookTransfer cmd) =>
            throw new NotImplementedException();
    }
}
