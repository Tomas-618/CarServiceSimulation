using System;
using System.Collections.Generic;

namespace CarServiceSimulation
{
    public static class ListExtension
    {
        public static bool TryRemoveValueByCondition<T>(this List<T> collection, Predicate<T> match, out T value)
        {
            value = collection.Find(match);

            if (value != null)
            {
                collection.Remove(value);

                return true;
            }

            return false;
        }
    }
}
