using Examples.Chapter02.Banking;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web.Mvc;

namespace Examples.Tests.Chapter05.BoC.Imperative
{
    /// <summary>
    /// Imparative approach
    /// </summary>
    public class MakeTransferController_Imparative : Controller
    {
        IValidator<MakeTransfer> validator;

        public void MakeTransfer([FromBody] MakeTransfer transfer)
        {
            if (validator.IsValid(transfer))
                Book(transfer);
        }

        void Book(MakeTransfer transfer) => throw new NotImplementedException();
    }
}
