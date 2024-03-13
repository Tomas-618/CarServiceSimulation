namespace CarServiceSimulation
{
    public class Engine : Detail
    {
        public Engine(in int cost, in bool isFixed) : base(nameof(Engine), cost, isFixed) { }
    }
}
