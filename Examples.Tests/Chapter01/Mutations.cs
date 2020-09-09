using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Tests.Chapter01
{
    class Mutations
    {
        [Test]
        public void NoInPlaceUpdates()
        {
            var original = new[] { 5, 7, 1 };
            var sorted = original.OrderBy(x => x).ToList();

            Assert.AreEqual(new[] { 5, 7, 1 }, original);
            Assert.AreEqual(new[] { 1, 5, 7 }, sorted);
        }

        [Test]
        public void InPlaceUpdates()
        {
            var original = new List<int> { 5, 7, 1 };
            original.Sort();

            Assert.AreEqual(new[] { 1, 5, 7 }, original);
        }
    }
}
