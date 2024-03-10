using System;

namespace CarServiceSimulation
{
    public class AutoServiceUI
    {
        private readonly IReadOnlyAutoService _entity;

        public AutoServiceUI(IReadOnlyAutoService entity) =>
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));

        public void ShowInfo(IReadOnlyCar car) =>
            Console.WriteLine($"{_entity}\n\n{nameof(Car)}Info:\n{car ?? throw new ArgumentNullException(nameof(car))}");
    }
}
