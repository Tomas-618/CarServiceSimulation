namespace CarServiceSimulation
{
    public class Brake : Detail
    {
        public Brake(in int cost, in bool isFixed) : base(nameof(Brake), cost, isFixed) { }
    }
}
