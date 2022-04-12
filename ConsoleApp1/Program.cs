using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("#=======================#");
            Console.WriteLine("# Welcome to Ten-Pin Bowling! #");
            Console.WriteLine("#=======================#");
            Console.WriteLine("Please enter Bowling score of whole game...");
            var input = Console.ReadLine();
            var game = new TenPinGame(string.IsNullOrEmpty(input) ? args[0] : input);

            Console.WriteLine("Game: {0}", string.IsNullOrEmpty(input) ? args[0] : input);
            Console.WriteLine("Score: " + game.Score());
            Console.WriteLine("#=====#");

            Console.WriteLine("Thank you for playing with us!");
            Console.WriteLine("Have a nice day!");
            Console.Read();
        }
    }
}
