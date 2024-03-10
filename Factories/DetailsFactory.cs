using System;
using System.Collections.Generic;
using System.Linq;

namespace CarServiceSimulation
{
    public class DetailsFactory
    {
        private readonly Dictionary<Type, Func<IReadOnlyDetail>> _map;

        public DetailsFactory(in bool isFixed) =>
            _map = CreateMap(isFixed);

        public IReadOnlyList<Type> Types => _map.Keys
            .ToList();

        public List<IReadOnlyDetail> Create(int[] counts)
        {
            if (counts == null)
                throw new ArgumentNullException(nameof(counts));

            if (counts.Length != Types.Count)
                throw new InvalidOperationException();

            List<IReadOnlyDetail> tempDetails = CreateDetailsAllTypes();
            List<IReadOnlyDetail> details = new List<IReadOnlyDetail>();

            for (int i = 0; i < tempDetails.Count; i++)
            {
                int currentDetailCount = counts[i];

                for (int j = 0; j < currentDetailCount; j++)
                    details.Add(tempDetails[i]);
            }

            return details;
        }

        public IReadOnlyDetail CreateRandomOne()
        {
            int typeIndex = Utils.GetRandomNumber(Types.Count);

            return CreateOneByType(Types[typeIndex]);
        }

        private List<IReadOnlyDetail> CreateDetailsAllTypes()
        {
            return _map
            .Select(detail => detail.Value.Invoke())
            .ToList();
        }

        private IReadOnlyDetail CreateOneByType(Type type) =>
            _map[type].Invoke();

        private Dictionary<Type, Func<IReadOnlyDetail>> CreateMap(bool isFixed)
        {
            return new Dictionary<Type, Func<IReadOnlyDetail>>
            {
                [typeof(CarBody)] = () => new CarBody(120, isFixed),
                [typeof(Suspension)] = () => new Suspension(30, isFixed),
            };
        }
    }
}