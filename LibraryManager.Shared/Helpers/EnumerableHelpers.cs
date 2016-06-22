using System;
using System.Collections.Generic;

namespace LibraryManager.Shared.Helpers
{
    public static class EnumerableHelpers
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
                action(item);

            return enumerable;
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable)
            => new HashSet<T>(enumerable);
    }
}