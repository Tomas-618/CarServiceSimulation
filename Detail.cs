using System;

namespace CarServiceSimulation
{
    public abstract class Detail : IReadOnlyDetail
    {
        protected Detail(string name, in int cost, in bool isFixed)
        {
            if (cost <= 0)
                throw new ArgumentOutOfRangeException(cost.ToString());

            Name = name ?? throw new ArgumentNullException(nameof(name));
            Cost = cost;
            IsFixed = isFixed;
        }

        public string Name { get; }
        
        public int Cost { get; }

        public bool IsFixed { get; private set; }

        public void Break() =>
            IsFixed = false;
    }
}
