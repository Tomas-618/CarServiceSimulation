namespace CarServiceSimulation
{
    public interface IReadOnlyAutoService
    {
        int Money { get; }

        bool CanWork { get; }
    }
}