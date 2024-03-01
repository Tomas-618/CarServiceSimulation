using System;
using System.Collections.Generic;

namespace CarServiceSimulation
{
    public class Town
    {
        private readonly Container _container;
        private readonly AutoService _service;

        public Town()
        {
            _container = new Container(CreateDetails(false));
            _service = new AutoService(CreateStorage());
        }

        public void Simulate()
        {
            bool isContinue = true;

            while (isContinue)
            {
                Car car = new Car(_container.GetRandomDetail());

                int fineCost = 163;

                _service.Work(car, fineCost);
                isContinue = ConsoleUtils.TryAnswer($"Do you want to continue auto service working? (y/n)");
                Console.Clear();
            }
        }

        private Storage CreateStorage()
        {
            Container container = new Container(CreateDetails(true));

            int[] detailsCounts = { 8, 10 };

            if (container.Capacity != detailsCounts.Length)
                throw new InvalidOperationException();

            Dictionary<Type, int> details = new Dictionary<Type, int>();

            for (int i = 0; i < container.Capacity; i++)
                details.Add(container.GetDetailTypeByIndex(i), detailsCounts[i]);

            return new Storage(details, container);
        }

        private List<Func<IReadOnlyDetail>> CreateDetails(bool isBroken)
        {
            return new List<Func<IReadOnlyDetail>>
            {
                () => new CarBody(2180, isBroken),
                () => new Suspension(327, isBroken)
            };
        }
    }
}
