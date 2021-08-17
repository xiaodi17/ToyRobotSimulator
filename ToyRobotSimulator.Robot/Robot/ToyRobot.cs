using System;
using Tabletop = ToyRobotSimulator.Robot.Tabletop.Tabletop;

namespace ToyRobotSimulator.Robot.Robot
{
    public class Robot : IRobot
    {
        private int _xAxisCurrentPosition;
        private int _yAxisCurrentPosition;
        private Direction _direction;
        // private Tabletop _tabletop;


        public void Place(string command)
        {
            var commandDetails = command.Split(",");
            if (!int.TryParse(commandDetails[0], out _xAxisCurrentPosition))
                return;
            
            if (!int.TryParse(commandDetails[1], out _yAxisCurrentPosition))
                return;

            if (!string.IsNullOrEmpty(commandDetails[2])) return;
            
            if (!Enum.TryParse(commandDetails[2], out _direction))
            {
                Console.WriteLine("Invalid direction");
            }



        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public void Left()
        {
            throw new System.NotImplementedException();
        }

        public void Right()
        {
            throw new System.NotImplementedException();
        }

        public string Report()
        {
            throw new System.NotImplementedException();
        }

        public bool IsValidCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        private bool IsValidPosition
        {
            
        }
    }
}