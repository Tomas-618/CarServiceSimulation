using System;
using System.Collections.Generic;
using System.Linq;

namespace CarServiceSimulation
{
    public class Container
    {
        public Container(IReadOnlyList<Func<IReadOnlyDetail>> details) =>
            Details = details ?? throw new ArgumentNullException(nameof(details));

        public IReadOnlyList<Func<IReadOnlyDetail>> Details { get; }

        public IReadOnlyList<Type> DetailsTypes => Details
            .Select(detail => detail?.Invoke().GetType())
            .ToList();

        public IReadOnlyDetail GetRandomDetail()
        {
            int index = Utils.GetRandomNumber(Details.Count);

            return Details[index]?.Invoke();
        }
    }
}
