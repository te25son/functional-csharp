using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chapter02.ListFormatter
{
    public class Numbered<T>
    {
        public Numbered(T value, int number)
        {
            Value = value;
            Number = number;
        }

        public int Number { get; set; }

        public T Value { get; set; }

        public override string ToString() =>
            $"({Number}, {Value})";

        public static Numbered<T> Create(T value, int number) =>
            new Numbered<T>(value, number);
    }
}
