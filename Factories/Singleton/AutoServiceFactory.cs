namespace CarServiceSimulation
{
    public class AutoServiceFactory
    {
        private static AutoServiceFactory s_instance;

        private readonly StorageFactory _storageFactory;

        private AutoServiceFactory() =>
            _storageFactory = new StorageFactory();

        public static AutoServiceFactory GetInstance()
        {
            if (s_instance == null)
                s_instance = new AutoServiceFactory();

            return s_instance;
        }

        public AutoService Create() =>
            new AutoService(_storageFactory.Create());
    }
}
