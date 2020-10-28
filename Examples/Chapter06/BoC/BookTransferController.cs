using Functional;
using Functional.Either;
using System;
using System.Web.Mvc;

namespace Examples.Chapter06.BoC
{
    public class BookTransferController : Controller
    {
        Either<Error, Unit> Handle(BookTransfer cmd) =>
            Validate(cmd)
                .Bind(Save);

        Either<Error, BookTransfer> Validate(BookTransfer cmd) =>
            throw new NotImplementedException();

        Either<Error, Unit> Save(BookTransfer cmd) =>
            throw new NotImplementedException();
    }
}
