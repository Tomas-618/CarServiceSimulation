﻿namespace CarServiceSimulation
{
    public class Suspension : Detail
    {
        public Suspension(in int cost, in bool isFixed) : base(nameof(Suspension), cost, isFixed) { }
    }
}
