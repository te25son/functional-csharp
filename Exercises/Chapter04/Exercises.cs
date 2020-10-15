using Exercises.Chapter01;
using Exercises.Chapter03;
using Functional;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises.Chapter04
{
    using static F;
    public class Exercises
    {
    }

    public static class ISetExt
    {
        public static ISet<R> Map<T, R>(this ISet<T> set, Func<T, R> f)
        {
            var result = new HashSet<R>();
            foreach (var s in set) 
                result.Add(f(s));
            return result;
        }
    }

    public static class IDictionaryExt
    {
        public static IDictionary<K, R> Map<K, T, R>(this IDictionary<K, T> dict, Func<T, R> f)
        {
            var result = new Dictionary<K, R>();
            foreach (var kvp in dict)
                result.Add(kvp.Key, f(kvp.Value));
            return result;
        }
    }

    public class Employee
    {
        public string Id { get; set; }

        public Option<WorkPermit> WorkPermit { get; set; }

        public DateTime JoinedOn { get; }

        public Option<DateTime> LeftOn { get; }
    }

    public class EmployeeComponent
    {
        public Option<WorkPermit> GetWorkPermit(Dictionary<string, Employee> employees, string employeeId) =>
            employees.Lookup(employeeId).Bind(e => e.WorkPermit);

        public Option<WorkPermit> GetValidWorkPermit(Dictionary<string, Employee> employees, string employeeId) =>
            employees
                .Lookup(employeeId)
                .Bind(e => e.WorkPermit)
                .Where(p => p.Expiry > DateTime.Now.Date);

        public double AverageYearsWorkedAtTheCompany(List<Employee> employees) =>
            employees
                .Bind(e => e.LeftOn.Map(leftOn => YearsBetween(e.JoinedOn, leftOn)))
                .Average();

        private double YearsBetween(DateTime start, DateTime end) =>
            (end - start).Days / 365d;
    }

    public static class EmployeeExt
    {
        public static Option<Employee> Lookup(this Dictionary<string, Employee> people, string employeeId)
        {
            Employee value;
            return people.TryGetValue(employeeId, out value)
                ? Some(value)
                : None;
        }
    }

    public struct WorkPermit
    {
        public string Number { get; set; }

        public DateTime Expiry { get; set; }
    }
}
