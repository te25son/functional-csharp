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
        private readonly IDateTimeService _clock;

        public DateValidator(IDateTimeService clock)
        {
            _clock = clock;
        }

        public bool IsValid(MakeTransfer transferCommand) =>
            _clock.NowUtc.Date <= transferCommand.DateUtc.Date;
    }
}
