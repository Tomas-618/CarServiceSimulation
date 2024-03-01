using System;
using System.Collections.Generic;

namespace CarServiceSimulation
{
    public class Container
    {
        private readonly IReadOnlyList<Func<IReadOnlyDetail>> _details;

        public Container(IReadOnlyList<Func<IReadOnlyDetail>> details) =>
            _details = details ?? throw new ArgumentNullException(nameof(details));

        public int Capacity => _details.Count;

        public bool IsIndexInRange(in int index) =>
            _details.IsIndexInRange(index);

        public IReadOnlyDetail GetDetailByIndex(in int index) =>
            _details[index]?.Invoke();

        public IReadOnlyDetail GetDetailByType(Type type)
        {
            List<Type> detailsTypes = new List<Type>();

            for (int i = 0; i < Capacity; i++)
                detailsTypes.Add(GetDetailTypeByIndex(i));

            return GetDetailByIndex(detailsTypes.IndexOf(type ?? throw new ArgumentNullException(nameof(type))));
        }

        public Type GetDetailTypeByIndex(in int index) =>
            GetDetailByIndex(index).GetType();

        public IReadOnlyDetail GetRandomDetail()
        {
            int index = Utils.GetRandomNumber(_details.Count);

            return _details[index]?.Invoke();
        }
    }
}
