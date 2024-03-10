using System;

namespace CarServiceSimulation
{
    public class Utils
    {
        private static readonly Random s_random;

        static Utils() =>
            s_random = new Random();

        public static int GetRandomNumber(in int maxValue) =>
            s_random.Next(maxValue);

        public static int GetRandomNumber(in int minValue, in int maxValue) =>
            s_random.Next(minValue, maxValue);
    }
}
