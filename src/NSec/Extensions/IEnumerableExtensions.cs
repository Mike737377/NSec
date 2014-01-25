using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSec
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> forEnumerable, Action<T> eachAction)
        {
            foreach (var item in forEnumerable)
            {
                eachAction(item);
            }
        }
    }
}