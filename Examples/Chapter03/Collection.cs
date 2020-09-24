using Functional;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Examples.Chapter03
{
    using static F;

    public static class Collection
    {
        public static Option<string> Lookup(this NameValueCollection collection, string key) =>
            collection[key];

        public static Option<T> Lookup<K, T>(this IDictionary<K, T> dict, K key)
        {
            T value;
            return dict.TryGetValue(key, out value)
                ? Some(value)
                : None;
        }
    }
}
