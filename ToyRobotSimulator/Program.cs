using System;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter a command:");
                var command = Console.ReadLine();
                
                if (string.IsNullOrEmpty(command))
                    continue;
                
                if (command.Equals("EXIT"))
                    break;
                
            }
            Console.WriteLine("You have exited the game.");
        }
    }
}
