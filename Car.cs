using System;

namespace CarServiceSimulation
{
    public class Car
    {
        private IReadOnlyDetail _detailToReplace;

        public Car(IReadOnlyDetail detailToReplace) =>
            _detailToReplace = detailToReplace ?? throw new ArgumentNullException(nameof(detailToReplace));

        public bool IsFixed => _detailToReplace.IsFixed;

        public bool TryReplaceDetail(IReadOnlyDetail newDetail)
        {
            if (newDetail == null)
                throw new ArgumentNullException(nameof(newDetail));

            if (_detailToReplace.GetType() == newDetail.GetType())
            {
                _detailToReplace = newDetail;

                return true;
            }

            return false;
        }
    }
}
