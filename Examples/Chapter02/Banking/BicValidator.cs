using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Examples.Chapter02.Banking
{
    /// <summary>
    /// Only validates that the BIC number is valid.
    /// </summary>
    public sealed class BicValidator : IValidator<MakeTransfer>
    {
        static readonly Regex regex = new Regex("^[A-Z]{6}[A-Z1-9]{5}$");

        public bool IsValid(MakeTransfer transferCommand) =>
            regex.IsMatch(transferCommand.Bic);
    }
}
