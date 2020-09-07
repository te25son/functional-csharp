using System.Collections.Generic;
using System.Linq;

namespace Examples.Chapter02
{
    public class MutatingArguments
    {
        // Mutates its input argument. Should always be avoided.
        public decimal RecomputeTotal_WithMutation(Order order, List<OrderLine> linesToDelete)
        {
            var result = 0m;
            foreach (var line in order.OrderLines)
                if (line.Quantity == 0) linesToDelete.Add(line);
                else result += line.Product.Price * line.Quantity;
            return result;
        }

        // Returns the computed information to the caller and does not mutate its input arguments.
        public (decimal, IEnumerable<OrderLine>) RecomputeTotal_WithoutMutation(Order order) => (
            order.OrderLines.Sum(l => l.Product.Price * l.Quantity),
            order.OrderLines.Where(l => l.Quantity == 0)
        );

        public class Product
        {
            public decimal Price { get; }
        }

        public class OrderLine
        {
            public Product Product { get; }
            public int Quantity { get; }

        }

        public class Order
        {
            public IEnumerable<OrderLine> OrderLines { get; }
        }
    }
}
