using System;
using System.Collections.Generic;
using System.Linq;

namespace CarServiceSimulation
{
    public class Storage
    {
        private readonly Dictionary<Type, int> _detailts;
        private readonly Container _container;

        public Storage(Dictionary<Type, int> details, Container container)
        {
            RemoveDetails(details);

            _detailts = details ?? throw new ArgumentNullException(nameof(details));
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public IReadOnlyDictionary<Type, int> Details => _detailts;

        public bool TryGetDetail(in int detailIndex, out IReadOnlyDetail detail)
        {
            detail = null;

            if (_container.Details.IsIndexInRange(detailIndex) == false)
                return false;

            Type detailType = _container.DetailsTypes[detailIndex];

            if (_detailts.ContainsKey(detailType))
            {
                _detailts[detailType]--;
                RemoveDetails(_detailts);
                
                detail = _container.Details[detailIndex]?.Invoke();

                return true;
            }

            return false;
        }

        private void RemoveDetails(Dictionary<Type, int> details)
        {
            details = details
                .Where(detail => detail.Value > 0)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}
