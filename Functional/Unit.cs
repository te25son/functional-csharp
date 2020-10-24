namespace Functional
{
    public struct Unit
    {
        public static Unit Value => new Unit();

        public static bool operator ==(Unit unit, Unit other) => true;

        public static bool operator !=(Unit unit, Unit other) => false;

        public override string ToString() => "empty";

        public override bool Equals(object obj) => obj is Unit;

        public override int GetHashCode() => 0;
    }
}
