using System;

namespace CarServiceSimulation
{
    public abstract class Detail : IReadOnlyDetail
    {
        protected Detail(in int cost, in bool isFixed)
        {
            if (cost <= 0)
                throw new ArgumentOutOfRangeException(cost.ToString());

            Cost = cost;
            IsFixed = isFixed;
        }
        
        public int Cost { get; }

        public bool IsFixed { get; private set; }

        public void Break() =>
            IsFixed = false;
    }
}
