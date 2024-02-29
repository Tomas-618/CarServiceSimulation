using System;

namespace CarServiceSimulation
{
    public class AutoService
    {
        private readonly Storage _storage;

        private int _money;

        public AutoService(Storage storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));

            int minValue = 3000;
            int maxValue = 5000;

            _money = Utils.GetRandomNumber(minValue, maxValue + 1);
        }

        public int Money
        {
            get => _money;
            private set => _money = value <= 0 ? 0 : value;
        }

        public bool CanWork => Money > 0;

        public void Work(Car brokenCar, in int fineCost)
        {
            if (CanWork == false)
                return;

            if (brokenCar == null)
                throw new ArgumentNullException(nameof(brokenCar));

            if (brokenCar.IsFixed)
                return;

            IReadOnlyDetail newDetail;

            int minPriceOfWork = 2;
            int maxPriceOfWork = 4;

            int priceOfWork = Utils.GetRandomNumber(minPriceOfWork, maxPriceOfWork + 1);

            bool isServeRefused = false;

            while (_storage.TryGetDetail(ConsoleUtils.GetNumber("Detail index: ") - 1, out newDetail) == false && isServeRefused == false)
            {
                Console.WriteLine($"\nCan't find this {nameof(Detail).ToLower()}");
                isServeRefused = ConsoleUtils.TryAnswer($"Do you want to try to get another {nameof(Detail).ToLower()}? (y/n)");
            }

            if (newDetail == null)
            {
                Money -= fineCost;

                return;
            }

            Money += (brokenCar.TryReplaceDetail(newDetail) && brokenCar.IsFixed ? newDetail.Cost : -newDetail.Cost) + priceOfWork;
        }
    }
}
