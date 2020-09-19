using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chapter02.Banking
{
    /// <summary>
    /// Only validates that the Date of the transfer is not in the past.
    /// </summary>
    public sealed class DateValidator : IValidator<MakeTransfer>
    {
        public bool IsValid(MakeTransfer transferCommand) =>
            DateTime.UtcNow.Date <= transferCommand.DateUtc.Date;
    }
}
