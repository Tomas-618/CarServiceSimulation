using System;
using System.Collections.Generic;

namespace CarServiceSimulation
{
    public class Storage
    {
        private readonly Dictionary<int, Type> _detailsTypesMap;
        private readonly List<IReadOnlyDetail> _details;

        public Storage(Dictionary<int, Type> detailsTypesMap, List<IReadOnlyDetail> details)
        {
            _detailsTypesMap = detailsTypesMap ?? throw new ArgumentNullException(nameof(detailsTypesMap));
            _details = details ?? throw new ArgumentNullException(nameof(details));
        }

        public int Count => _details.Count;

        public bool TryGetDetail(in int detailIndex, out IReadOnlyDetail detail)
        {
            detail = null;

            if (_detailsTypesMap.TryGetValue(detailIndex, out Type detailType) == false)
                return false;

            return _details.TryRemoveValueByCondition(currentDetail => currentDetail.GetType() == detailType, out detail);
        }

        public override string ToString()
        {
            string info = "Details:\n";

            foreach (KeyValuePair<int, Type> pair in _detailsTypesMap)
                info += $"{pair}\n";

            info += "\n";

            _details.ForEach(detail => info += $"{detail}\n");

            return info;
        }
    }
}
