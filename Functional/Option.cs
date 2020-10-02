using Functional.Option;
using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
    using static F;

    public static partial class F
    {
        public static None None =>
            None.Default;

        public static Option<T> Some<T>(T value) =>
            new Some<T>(value);
    }

    public struct Option<T>
    {
        readonly bool _isSome;
        readonly T _value;

        private Option(T value)
        {
            _isSome = true;
            _value = value;
        }

        public static implicit operator Option<T>(None _) =>
            new Option<T>();

        public static implicit operator Option<T>(Some<T> some) =>
            new Option<T>(some.Value);

        public static implicit operator Option<T>(T value) =>
            value == null ? None : Some(value);

        public R Match<R>(Func<R> none, Func<T, R> some) =>
            _isSome ? some(_value) : none();

        public override string ToString() =>
            _isSome ? "Some" : "None";
    }

    namespace Option
    {
        public struct None
        {
            internal static readonly None Default = new None();
        }

        public struct Some<T>
        {
            internal T Value { get; }

            internal Some(T value)
            {
                if (value == null)
                    throw new ArgumentNullException();
                Value = value;
            }
        }
    }
}
