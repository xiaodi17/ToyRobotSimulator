using System;
using ToyRobotSimulator.Robot.Tabletop;

namespace ToyRobotSimulator.Robot.Robot
{
    public class ToyRobot : IRobot
    {
        private int _xCurrentPosition = -1;
        private int _yCurrentPosition = -1;
        private Direction _direction;
        private TabletopMap _tabletopMap;

        private bool IsCurrentPositionValid(int xPosition, int yPosition)
        {
            return xPosition >= 0 && xPosition < _tabletopMap.XAxisLength
                                  && yPosition >= 0
                                  && yPosition < _tabletopMap.YAxisLength;
        }


        public ToyRobot(TabletopMap tabletopMap)
        {
            _tabletopMap = tabletopMap;
        }

        public bool TryPlace(string command)
        {
            char[] splitChar =  {',', ' '};
            var commandDetails = command.Split(splitChar);
            
            if (!int.TryParse(commandDetails[1], out _xCurrentPosition))
                return false;
            
            if (!int.TryParse(commandDetails[2], out _yCurrentPosition))
                return false;

            if (string.IsNullOrEmpty(commandDetails[3]))
                return false;
            
            if (!Enum.TryParse(commandDetails[2], out _direction))
            {
                Console.WriteLine("Invalid direction");
            }

            if (!IsCurrentPositionValid(_xCurrentPosition, _yCurrentPosition))
            {
                Console.WriteLine("Place at invalid position");
                return false;
            }

            return true;
        }

        public void Move()
        {
            switch (_direction)
            {
                case Direction.East:
                    if (IsCurrentPositionValid(_xCurrentPosition + 1, _yCurrentPosition)) 
                        _xCurrentPosition++;
                    break;
                case Direction.North:
                    if (IsCurrentPositionValid(_xCurrentPosition, _yCurrentPosition + 1)) 
                        _yCurrentPosition++;
                    break;
                case Direction.South:
                    if (IsCurrentPositionValid(_xCurrentPosition, _yCurrentPosition - 1)) 
                        _yCurrentPosition--;
                    break;
                case Direction.West:
                    if (IsCurrentPositionValid(_xCurrentPosition - 1, _yCurrentPosition)) 
                        _xCurrentPosition--;
                    break;
            }
        }

        public void Left()
        {
            switch (_direction)
            {
                case Direction.East:
                    _direction = Direction.North;
                    break;
                case Direction.North:
                    _direction = Direction.West;
                    break;
                case Direction.South:
                    _direction = Direction.East;
                    break;
                case Direction.West:
                    _direction = Direction.South;
                    break;
            }
        }

        public void Right()
        {
            switch (_direction)
            {
                case Direction.East:
                    _direction = Direction.South;
                    break;
                case Direction.North:
                    _direction = Direction.East;
                    break;
                case Direction.South:
                    _direction = Direction.West;
                    break;
                case Direction.West:
                    _direction = Direction.North;
                    break;
            }
        }

        public string Report()
        {
            if (!IsCurrentPositionValid(_xCurrentPosition, _yCurrentPosition))
                return string.Empty;

            return $"X: {_xCurrentPosition}, Y: {_yCurrentPosition}, Facing: {_direction}";
        }

        public bool IsCommandValid(Command command)
        {
            switch (command)
            {
                case Command.Place:
                    return true;
                
                default:
                    return _xCurrentPosition > -1 && _yCurrentPosition > -1;
            }
        }
    }
}