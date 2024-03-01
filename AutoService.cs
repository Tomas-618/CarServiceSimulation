using System;

namespace CarServiceSimulation
{
    public class AutoService : IReadOnlyAutoService
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

        public bool CanWork => Money > 0 && _storage.Capacity > 0;

        public void Work(Car car, in int fineCost)
        {
            if (car == null)
                throw new ArgumentNullException(nameof(car));

            if (CanWork == false)
            {
                Console.WriteLine($"Sorry, {nameof(AutoService)} can't work");

                return;
            }

            if (car.IsFixed)
            {
                Console.WriteLine($"{nameof(Car)} is already fixed!");

                return;
            }

            int minPriceOfWork = 2;
            int maxPriceOfWork = 4;

            int priceOfWork = Utils.GetRandomNumber(minPriceOfWork, maxPriceOfWork + 1);

            if (TryGetDetail(fineCost, out IReadOnlyDetail newDetail) == false)
                return;

            if (car.TryReplaceDetail(newDetail) && car.IsFixed)
            {
                Money += newDetail.Cost;
                Console.Write("Car was succesfully fixed! Your prize: ");
            }
            else
            {
                Money -= newDetail.Cost;
                Console.Write("You failed to fix the car! You've lost: ");
            }

            Money += priceOfWork;

            Console.WriteLine(newDetail.Cost);
            Console.WriteLine($"You've get {priceOfWork}, as price of work");
        }

        private bool TryGetDetail(in int fineCost, out IReadOnlyDetail newDetail)
        {
            if (fineCost <= 0)
                throw new ArgumentOutOfRangeException(fineCost.ToString());

            bool isServeRefused = false;

            while (_storage.TryGetDetail(ConsoleUtils.GetNumber("Detail index: ") - 1, out newDetail) == false && isServeRefused == false)
            {
                Console.WriteLine($"\nCan't find this {nameof(Detail).ToLower()}");
                isServeRefused = ConsoleUtils.TryAnswer($"Do you want to try to get another {nameof(Detail).ToLower()}? (y/n)");
            }

            if (newDetail == null)
            {
                Money -= fineCost;
                Console.WriteLine($"You have been fined for not serve your client || Fine cost: {fineCost}");

                return false;
            }

            return true;
        }

        public override string ToString() =>
            $"{_storage}\n{nameof(Money)}: {Money}";
    }
}
