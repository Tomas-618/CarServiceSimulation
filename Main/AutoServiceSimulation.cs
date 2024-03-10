using System;

namespace CarServiceSimulation
{
    public class AutoServiceSimulation
    {
        private readonly AutoService _autoService;
        private readonly AutoServiceUI _autoServiceUI;
        private readonly CarFactory _carFactory;

        public AutoServiceSimulation()
        {
            _autoService = AutoServiceFactory.GetInstance().Create();
            _autoServiceUI = new AutoServiceUI(_autoService);
            _carFactory = new CarFactory();
        }

        public void Process()
        {
            bool isWorking = true;

            while (isWorking)
            {
                Car car = _carFactory.Create();

                _autoServiceUI.ShowInfo(car);
                Console.WriteLine();
                _autoService.Work(car);

                isWorking = _autoService.CanWork && ConsoleUtils.TryAnswer("\nDo you want to continue? (y/n)");
                Console.Clear();
            }
        }
    }
}
