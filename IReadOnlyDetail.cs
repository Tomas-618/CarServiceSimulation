namespace CarServiceSimulation
{
    public interface IReadOnlyDetail
    {
        string Name { get; }

        int Cost { get; }

        bool IsFixed { get; }
    }
}
