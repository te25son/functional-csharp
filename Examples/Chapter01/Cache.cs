using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chapter01
{
    class Cache<T> where T : class
    {
        public T Get(Guid id, Func<T> onMiss)
            => Get(id) ?? onMiss();

        public T Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
