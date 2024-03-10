namespace CarServiceSimulation
{
    public class CarFactory
    {
        private readonly DetailsFactory _detailsFactory;

        public CarFactory()
        {
            bool isDetailsFixed = false;

            _detailsFactory = new DetailsFactory(isDetailsFixed);
        }

        public Car Create() =>
            new Car(_detailsFactory.CreateRandomOne());
    }
}
