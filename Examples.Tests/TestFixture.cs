using Examples.Chapter02.ListFormatter;
using System;

namespace Examples.Tests
{
    public class TestFixture
    {
        protected void Test<TArrangeResult, TActResult>(
            Func<TArrangeResult> arrange,
            Func<TArrangeResult, TActResult> act,
            Action<TArrangeResult, TActResult> assert)
        {
            var arrangeResult = arrange();
            assert(arrangeResult, act(arrangeResult));
        }
    }
}
