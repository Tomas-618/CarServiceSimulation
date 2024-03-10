using System;
using System.Collections.Generic;

namespace CarServiceSimulation
{
    public class DetailsTypesMapFactory
    {
        public Dictionary<int, Type> CreateDetailsTypesMap(Type[] detailsTypes)
        {
            Dictionary<int, Type> detailsTypesMap = new Dictionary<int, Type>();

            for (int i = 0; i < detailsTypes.Length; i++)
            {
                int index = i + 1;

                detailsTypesMap.Add(index, detailsTypes[i]);
            }

            return detailsTypesMap;
        }
    }
}
