namespace CarServiceSimulation
{
    public class Transmission : Detail
    {
        public Transmission(in int cost, in bool isFixed) : base(nameof(Transmission), cost, isFixed) { }
    }
}
