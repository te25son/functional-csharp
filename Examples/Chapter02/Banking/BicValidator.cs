using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Examples.Chapter02.Banking
{
    /// <summary>
    /// Only validates that the BIC number is valid.
    /// </summary>
    public sealed class BicValidator : IValidator<MakeTransfer>
    {
        readonly Func<IEnumerable<string>> _getValidCodes;

        public BicValidator(Func<IEnumerable<string>> getValidCodes)
        {
            _getValidCodes = getValidCodes;
        }

        public bool IsValid(MakeTransfer transferCommand) =>
            _getValidCodes().Contains(transferCommand.Bic);
    }
}
