using System;

namespace Examples.Chapter02.Banking
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
