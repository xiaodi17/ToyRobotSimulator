using System;
using ToyRobotSimulator.Robot.Message;
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
            Console.WriteLine(RobotMessage.ROBOT_SIMULATOR_INSTRUCTION);
            var command = Console.ReadLine();
            
            while (!string.Equals(command, "exit", StringComparison.OrdinalIgnoreCase))
            {
                switch (command.ToLower())
                {
                    case var place when place.StartsWith("place", StringComparison.OrdinalIgnoreCase):
                        _robot.Place(place);
                        break;
                    
                    case "move":
                        _robot.Move();
                        break;
                    
                    case "left":
                        _robot.Left();
                        break;
                    
                    case "right":
                        _robot.Right();
                        break;
                    
                    case "report":
                        _robot.Report();
                        break;
                    
                    case "exit":
                        return;
                        
                    default:
                        Console.WriteLine(RobotMessage.INVALID_COMMAND);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}