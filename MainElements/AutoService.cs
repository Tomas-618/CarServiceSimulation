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

            int minValue = 8000;
            int maxValue = 15000;

            _money = Utils.GetRandomNumber(minValue, maxValue + 1);
        }

        public int Money
        {
            get => _money;
            private set => _money = value <= 0 ? 0 : value;
        }

        public bool CanWork => Money > 0 && _storage.Count > 0;

        public void Work(Car car)
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

            int priceOfWork = GetRandomPriceOfWork();
            int fineCost = GetRandomFineCost();

            if (TryGetDetail(fineCost, out IReadOnlyDetail newDetail) == false)
                return;

            if (car.TryReplaceDetail(newDetail) && car.IsFixed)
            {
                IncreaseMoney(newDetail.Cost);
                Console.Write("Car was succesfully fixed! Your prize: ");
            }
            else
            {
                ReduceMoney(newDetail.Cost);
                Console.Write("You failed to fix the car! You've lost: ");
            }

            Money += priceOfWork;

            Console.WriteLine(newDetail.Cost);
            Console.WriteLine($"You've got {priceOfWork}, as price of work");
        }

        public override string ToString() =>
            $"{_storage}\n{nameof(Money)}: {Money}";

        private bool TryGetDetail(in int fineCost, out IReadOnlyDetail newDetail)
        {
            if (fineCost <= 0)
                throw new ArgumentOutOfRangeException(fineCost.ToString());

            bool isServiceRefused = false;

            newDetail = null;

            while (isServiceRefused == false && _storage.TryGetDetail(ConsoleUtils.GetNumber("Detail index: "), out newDetail) == false)
            {
                Console.WriteLine($"\nCan't find this {nameof(Detail).ToLower()}");
                isServiceRefused = ConsoleUtils.TryAnswer("Do you want to refuse to service this car? (y/n)");
            }

            if (isServiceRefused)
            {
                Money -= fineCost;
                Console.WriteLine($"You have been fined for not serve your client || Fine cost: {fineCost}");

                return false;
            }

            return true;
        }

        private int GetRandomPriceOfWork()
        {
            int minPriceOfWork = 20;
            int maxPriceOfWork = 40;

            return Utils.GetRandomNumber(minPriceOfWork, maxPriceOfWork + 1);
        }

        private int GetRandomFineCost()
        {
            int minFineCost = 1500;
            int maxFineCost = 3000;

            return Utils.GetRandomNumber(minFineCost, maxFineCost + 1);
        }

        private void ReduceMoney(int cost)
        {
            if (cost <= 0)
                throw new ArgumentOutOfRangeException(cost.ToString());

            Money -= cost;
        }

        private void IncreaseMoney(int cost)
        {
            if (cost <= 0)
                throw new ArgumentOutOfRangeException(cost.ToString());

            Money += cost;
        }
    }
}
