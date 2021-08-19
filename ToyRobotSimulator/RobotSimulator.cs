using System;
using ToyRobotSimulator.Robot.Robot;

namespace ToyRobotSimulator
{
    public class RobotSimulator
    {
        private IRobot _robot;
        
        public RobotSimulator(IRobot robot)
        {
            _robot = robot;
        }

        public void Execute()
        {
            Console.WriteLine("Please enter a command:");
            var command = Console.ReadLine();
            
            while (!string.Equals(command, "exit", StringComparison.OrdinalIgnoreCase))
            {
                switch (command.ToLower())
                {
                    case var place when place.StartsWith("place", StringComparison.OrdinalIgnoreCase):
                        Place(place);
                        break;
                    
                    case "move":
                        Move();
                        break;
                    
                    case "left":
                        RotateToLeft();
                        break;
                    
                    case "right":
                        RotateToRight();
                        break;
                    
                    case "report":
                        Report();
                        break;
                        
                    default:
                        Console.WriteLine("Please use a valid command");
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private void Report()
        {
            if (_robot.IsCommandValid(Command.Report))
            {
                Console.WriteLine($"Robot is at {_robot.Report()}");
            }
            
            Console.WriteLine("You have to use place command before using other commands");
        }

        private void RotateToRight()
        {
            if (_robot.IsCommandValid(Command.Right))
            {
                _robot.TryRight();
                Console.WriteLine($"Robot has been successfully rotated to the right, the current position is: {_robot.Report()}");
            }
            
            Console.WriteLine("You have to use place command before using other commands");
        }

        private void RotateToLeft()
        {
            if (_robot.TryLeft())
            {
                Console.WriteLine($"Robot has been successfully rotated to the left, the current position is: {_robot.Report()}");
            }
            
            Console.WriteLine("You have to use place command before using other commands");
        }

        private void Move()
        {
            if (_robot.IsCommandValid(Command.Move))
            {
                if (!_robot.TryMove())
                {
                    Console.WriteLine("Robot cannot be moved");
                }
                Console.WriteLine($"Robot has been successfully moved to: {_robot.Report()}");
            }
        }

        private void Place(string place)
        {
            if (_robot.IsCommandValid(Command.Place))
            {
                var valid = _robot.TryPlace(place);

                if (!valid)
                {
                    Console.WriteLine("You didn't place robot at a valid position");
                    Console.WriteLine("Please enter a valid command");
                    return;
                }
                
                Console.WriteLine($"Robot has been successfully placed to: {_robot.Report()}");
            }
        }
    }
}