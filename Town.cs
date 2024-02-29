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
            }
        }

        private Storage CreateStorage()
        {
            Container container = new Container(CreateDetails(true));

            int[] tempDetailsCounts = { 8, 10 };

            if (container.Details.Count != tempDetailsCounts.Length)
                throw new InvalidOperationException();

            Dictionary<Type, int> detailsCounts = new Dictionary<Type, int>();

            for (int i = 0; i < container.Details.Count; i++)
                detailsCounts.Add(container.DetailsTypes[i], tempDetailsCounts[i]);

            return new Storage(detailsCounts, container);
        }

        private List<Func<Detail>> CreateDetails(bool isBroken)
        {
            return new List<Func<Detail>>
            {
                () => new CarBody(2180, isBroken),
                () => new Suspension(327, isBroken)
            };
        }
    }
}
