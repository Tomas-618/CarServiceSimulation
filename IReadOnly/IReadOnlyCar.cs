namespace CarServiceSimulation
{
    public interface IReadOnlyCar
    {
        IReadOnlyDetail DetailToReplace { get; }

        bool IsFixed { get; }
    }
}