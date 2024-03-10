using System;

namespace CarServiceSimulation
{
    public class ConsoleUtils
    {
        public static int GetNumber(string text)
        {
            int number;

            Console.Write(text);

            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.WriteLine($"\nCan't convert to {nameof(Int32)}. Try again");
                Console.Write(text);
            }

            return number;
        }

        public static bool TryAnswer(string text, string positive = "y", string negative = "n")
        {
            Console.WriteLine(text);
            string userInput = Console.ReadLine();

            while (userInput.ToLower() != positive.ToLower() && userInput.ToLower() != negative.ToLower())
            {
                Console.WriteLine("\nError! Try again!");

                Console.WriteLine(text);
                userInput = Console.ReadLine();
            }

            return userInput.ToLower() == positive.ToLower();
        }
    }
}
