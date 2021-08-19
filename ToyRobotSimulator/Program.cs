using System;
using ToyRobotSimulator.Robot.Robot;
using ToyRobotSimulator.Robot.Tabletop;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var tabletop = new TabletopMap();
            var robot = new ToyRobot(tabletop);
            var robotSimulator = new RobotSimulator(robot);

            try
            {
                robotSimulator.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error has occurred: {e.Message} Press enter to exit the program.");
                Console.Read();
            }
            
            Console.WriteLine("Toy robot simulator terminated");
        }
    }
}
