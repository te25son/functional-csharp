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
        private readonly DateTime _nowUtc;

        public DateValidator(DateTime now)
        {
            // A lot more can be done here to make sure everything is actually UTC.
            _nowUtc = now;
        }

        public bool IsValid(MakeTransfer transferCommand) =>
            _nowUtc <= transferCommand.DateUtc;
    }
}
