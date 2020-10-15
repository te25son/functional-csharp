using Functional;
using System;

namespace Exercises.Chapter04
{
    public class Exercises
    {
    }

    public class Employee
    {
        public string Id { get; set; }

        public Option<WorkPermit> WorkPermit { get; set; }

        public DateTime JoinedOn { get; }

        public Option<DateTime> LeftOn { get; }
    }

    public struct WorkPermit
    {
        public string Number { get; set; }

        public DateTime Expiry { get; set; }
    }
}
