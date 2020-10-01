﻿using Functional;
using System;

namespace Examples.Tests
{
    using Unit = ValueTuple;
    using static F;

    public class TestFixture
    {
        protected void Test<TArrangeResult, TActResult>(
            Func<Unit, TArrangeResult> arrange,
            Func<TArrangeResult, TActResult> act,
            Action<TArrangeResult, TActResult> assert)
        {
            var arrangeResult = arrange(Unit());
            assert(arrangeResult, act(arrangeResult));
        }

        protected string OptionToString<T>(Option<T> optT) =>
            optT.Match(
                () => "None",
                (t) => "Some");
    }
}
