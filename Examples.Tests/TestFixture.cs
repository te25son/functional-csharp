using Examples.Chapter02.ListFormatter;
using System;

namespace Examples.Tests
{
    public class TestFixture
    {
        protected void Test<TArrangeResult, TActResult>(
            Func<TArrangeResult> arrange,
            Func<ListFormatter, TArrangeResult, TActResult> act,
            Action<TActResult> assert
        ) => assert(act(new ListFormatter(), arrange()));
    }
}
