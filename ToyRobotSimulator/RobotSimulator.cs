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
                // if (string.IsNullOrEmpty(command))
                //     continue;
                
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
            throw new NotImplementedException();
        }

        private void RotateToRight()
        {
            throw new NotImplementedException();
        }

        private void RotateToLeft()
        {
            throw new NotImplementedException();
        }

        private void Move()
        {
            throw new NotImplementedException();
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