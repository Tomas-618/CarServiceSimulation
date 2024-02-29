namespace CarServiceSimulation
{
    public interface IReadOnlyDetail
    {
        int Cost { get; }

        bool IsFixed { get; }
    }
}
