using System;
using System.Collections.Generic;

namespace TrumpTwitter.Extensions
{
    static class IEnumerableExtensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static int IndexOf<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            int index = 0;
            foreach (var item in source)
            {
                if (item.Equals(value)) return index;
                index++;
            }
            return -1;
        }
    }
}
