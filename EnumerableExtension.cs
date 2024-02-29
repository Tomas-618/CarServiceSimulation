using System.Collections.Generic;
using System.Linq;

namespace CarServiceSimulation
{
    public static class EnumerableExtension
    {
        public static bool IsIndexInRange<T>(this IEnumerable<T> enumerable, in int index) =>
            index >= 0 && index < enumerable.Count();
    }
}
