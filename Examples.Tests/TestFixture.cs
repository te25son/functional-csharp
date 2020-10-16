using Functional;
using System;

namespace Examples.Tests
{
    using Unit = ValueTuple;
    using static F;

    public class TestFixture
    {
        /// <summary>
        /// Test that implements the AAA method, but where the assert step
        /// takes both the arrange and act steps as parameters.
        /// </summary>
        protected void Test<TArrangeResult, TActResult>(
            Func<Unit, TArrangeResult> arrange,
            Func<TArrangeResult, TActResult> act,
            Action<TArrangeResult, TActResult> assert)
        {
            var arrangeResult = arrange(Unit());
            assert(arrangeResult, act(arrangeResult));
        }

        /// <summary>
        /// Test that implements the AAA method in its most traditional form.
        /// </summary>
        protected void Test<TArrangeResult, TActResult>(
            Func<Unit, TArrangeResult> arrange,
            Func<TArrangeResult, TActResult> act,
            Action<TActResult> assert)
        {
            assert(act(arrange(Unit())));
        }

        /// <summary>
        /// Test that only implements arrange and act. Should only be used with NUnits
        /// `ExpectedResult` paramter for `TestCase`, or an equivalent in another library.
        /// </summary>
        protected TActResult Test<TArrangeResult, TActResult>(
            Func<Unit, TArrangeResult> arrange,
            Func<TArrangeResult, TActResult> act)
        {
            return act(arrange(Unit()));
        }
    }
}
