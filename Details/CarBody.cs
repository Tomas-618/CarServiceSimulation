﻿namespace CarServiceSimulation
{
    public class CarBody : Detail
    {
        public CarBody(in int cost, in bool isFixed) : base(nameof(CarBody), cost, isFixed) { }
    }
}
