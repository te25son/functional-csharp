using Examples.Chapter02.Banking;
using Functional;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web.Mvc;

namespace Examples.Tests.Chapter05.BoC
{
    using static Functional.F;

    class MakeTransferController_Functional : Controller
    {
        IValidator<MakeTransfer> validator;

        public void MakeTransfer([FromBody] MakeTransfer transfer) =>
            Some(transfer)
                .Map(Normalize)
                .Where(validator.IsValid)
                .ForEach(Book);

        void Book(MakeTransfer transfer) => throw new NotImplementedException();

        MakeTransfer Normalize(MakeTransfer transfer) => transfer;
    }
}
