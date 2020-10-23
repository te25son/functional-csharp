namespace Functional
{
    public struct Right<R>
    {
        internal R Value { get; }

        internal Right(R value) { Value = value; }

        public override string ToString() => $"Right({Value})";
    }
}
