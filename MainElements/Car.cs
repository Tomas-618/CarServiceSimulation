using System;

namespace CarServiceSimulation
{
    public class Car : IReadOnlyCar
    {
        public Car(IReadOnlyDetail detailToReplace) =>
            DetailToReplace = detailToReplace ?? throw new ArgumentNullException(nameof(detailToReplace));

        public IReadOnlyDetail DetailToReplace { get; private set; }

        public bool IsFixed => DetailToReplace.IsFixed;

        public bool TryReplaceDetail(IReadOnlyDetail newDetail)
        {
            if (newDetail == null)
                throw new ArgumentNullException(nameof(newDetail));

            if (DetailToReplace.GetType() == newDetail.GetType())
            {
                DetailToReplace = newDetail;

                return true;
            }

            return false;
        }

        public override string ToString() =>
            $"Detail to replace: {DetailToReplace}\nIs car fixed: {IsFixed}";
    }
}
