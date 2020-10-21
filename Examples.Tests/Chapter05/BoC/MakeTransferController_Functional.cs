using Examples.Chapter02.Banking;
using Functional;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web.Mvc;

namespace Examples.Tests.Chapter05.BoC.Functional
{
    using static F;

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

    /// <summary>
    /// In FP the data and behavior are separated. Data is considered "dumb"
    /// in this case and so its state cannot be changed.
    /// </summary>
    public class Account
    {
        public decimal Balance { get; }

        public Account(decimal balance)
        {
            Balance = balance;
        }
    }

    public static class AccountBehavior
    {
        public static Option<Account> Debit(this Account account, decimal amount) =>
            (account.Balance < amount)
                ? None
                : Some(new Account(account.Balance - amount));
    }
}
