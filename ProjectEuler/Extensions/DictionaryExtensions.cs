using System.Collections.Generic;

namespace ProjectEuler.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Increments the value at a given key. Starts at 1 if key does not exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        public static void Increment<T>(this Dictionary<T, int> dictionary, T key)
        {
            dictionary.TryGetValue(key, out var count);
            dictionary[key] = count + 1;
        }
    }
}
