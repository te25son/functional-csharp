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

    /// <summary>
    /// In OOP, data and behavior live in the same object,
    /// and methods can sometimes change the objects state.
    /// </summary>
    public class Account
    {
        public decimal Balance { get; private set; }

        public Account(decimal balance)
        {
            Balance = balance;
        }

        public void Debit(decimal amount)
        {
            if (Balance < amount)
                throw new InvalidOperationException("Insufficient funds");

            Balance -= amount;
        }
    }
}
