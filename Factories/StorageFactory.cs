using System;
using System.Linq;

namespace CarServiceSimulation
{
    public class StorageFactory
    {
        private readonly DetailsFactory _detailsFactory;
        private readonly DetailsTypesMapFactory _detailsTypesMapFactory;

        public StorageFactory()
        {
            bool isDetailsFixed = true;

            _detailsFactory = new DetailsFactory(isDetailsFixed);
            _detailsTypesMapFactory = new DetailsTypesMapFactory();
        }

        public Storage Create()
        {
            Type[] detailsTypes = _detailsFactory.Types
                .ToArray();

            int[] detailsCounts = { 4, 10, 11, 3, 8, 6 };

            return new Storage(_detailsTypesMapFactory.CreateDetailsTypesMap(detailsTypes), _detailsFactory.Create(detailsCounts));
        }
    }
}