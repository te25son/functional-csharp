using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chapter02.ListFormatter
{
    public static class StringExtension
    {
        public static string ToSentenceCase(this string origin) =>
            origin.ToUpper()[0] + origin.ToLower().Substring(1);
    }
}
