using System;
using System.Collections.Generic;

namespace ImageLib
{
    public static class LinqExtensions
    {
        public static void Do<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source) action(item);
        }
    }
}
