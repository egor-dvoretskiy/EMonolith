using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Extensions.Dictionaries
{
    public static class ConcurrentDictionaryExtensions
    {
        /// <summary>
        /// Simplifies usage of standart function ConcurrentDictionary<Key, Value>.AddOrUpdate(key, value, func).
        /// </summary>
        /// <typeparam name="Key">Type of the key.</typeparam>
        /// <typeparam name="Value">Type of the value.</typeparam>
        /// <param name="dictionary">Calling dictionary.</param>
        /// <param name="key">Value of the key.</param>
        /// <param name="value">Paired to key value.</param>
        public static void AddOrUpdate<Key, Value>(this ConcurrentDictionary<Key, Value> dictionary, Key key, Value value)
        {
            dictionary.AddOrUpdate(key, value, (k, v) => value);
        }
    }
}
