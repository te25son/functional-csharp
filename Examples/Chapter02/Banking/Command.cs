using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chapter02.Banking
{
    public abstract class Command
    {
    }

    public sealed class MakeTransfer : Command
    {
        public Guid DebitedAccountId { get; set; }

        public string Beneficiary { get; set; }

        public string Iban { get; set; }

        public string Bic { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateUtc { get; set; }
    }
}
