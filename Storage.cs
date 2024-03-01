using System;
using System.Collections.Generic;
using System.Linq;

namespace CarServiceSimulation
{
    public class Storage
    {
        private readonly Dictionary<Type, int> _details;
        private readonly Container _container; //проблемное место

        public Storage(Dictionary<Type, int> details, Container container)
        {
            RemoveDetails(details);

            _details = details ?? throw new ArgumentNullException(nameof(details));
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public int Capacity => _details.Count;

        public bool TryGetDetail(in int detailIndex, out IReadOnlyDetail detail)
        {
            detail = null;

            if (_container.IsIndexInRange(detailIndex) == false)
                return false;

            Type detailType = _container.GetDetailTypeByIndex(detailIndex);

            if (_details.ContainsKey(detailType))
            {
                _details[detailType]--;
                RemoveDetails(_details);
                
                detail = _container.GetDetailByIndex(detailIndex);

                return true;
            }

            return false;
        }

        public override string ToString()
        {
            string info = "Details:\n";

            int detailIndex = 0;

            foreach (KeyValuePair<Type, int> pair in _details)
            {
                IReadOnlyDetail detail = _container.GetDetailByType(pair.Key);

                info += $"{detailIndex}) {detail.Name}: Cost: {detail.Cost} || Count: {pair.Value}\n";
            }

            return info;
        }

        private void RemoveDetails(Dictionary<Type, int> details)
        {
            details = details
                .Where(detail => detail.Value > 0)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}
