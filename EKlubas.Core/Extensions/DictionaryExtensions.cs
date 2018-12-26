using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Core.Extensions
{
    public static class DictionaryExtensions
    {
        public static T GetValue<TKey, T>(this Dictionary<TKey, T> dictionary, TKey key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }

            return default(T);
        }

        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Dictionary<TKey, TValue> dictionaryToAdd)
        {
            dictionaryToAdd.ForEach(x => dictionary.Add(x.Key, x.Value));
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }
    }
}
