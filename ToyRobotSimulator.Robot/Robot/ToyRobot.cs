using System;
using System.Text.RegularExpressions;
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

        public Direction GetDirection()
        {
            return _direction;
        }

        public bool TryPlace(string command)
        {
            var stringWithoutWhitespaces = Regex.Replace(command.Substring(5), @"\s+", "");
            var commandDetails = stringWithoutWhitespaces.Split(',');

            if (commandDetails.Length < 2 || commandDetails.Length > 3)
                return false;
            
            if (!int.TryParse(commandDetails[0], out var xMovePosition))
                return false;
            
            if (!int.TryParse(commandDetails[1], out var yMovePosition))
                return false;

            if (commandDetails.Length == 3)
            {
                if (string.IsNullOrEmpty(commandDetails[2]))
                    return false;
                
                if (!Enum.TryParse(commandDetails[2], true, out _direction))
                {
                    Console.WriteLine("Invalid direction");
                }
            }

            if (!IsCurrentPositionValid(xMovePosition, yMovePosition))
            {
                Console.WriteLine("Place at invalid position");
                return false;
            }

            if (IsCurrentPositionValid(xMovePosition, yMovePosition) && _direction == Direction.Undefined)
            {
                Console.WriteLine("Invalid place operation, the first place operation has to include a facing direction.");
                return false;
            }

            _xCurrentPosition = xMovePosition;
            _yCurrentPosition = yMovePosition;

            return true;
        }

        public bool TryMove()
        {
            switch (_direction)
            {
                case Direction.East:
                    if (!IsCurrentPositionValid(_xCurrentPosition + 1, _yCurrentPosition))
                        return false;
                    _xCurrentPosition++;
                    return true;
                case Direction.North:
                    if (!IsCurrentPositionValid(_xCurrentPosition, _yCurrentPosition + 1))
                        return false;
                    _yCurrentPosition++;
                    return true;
                case Direction.South:
                    if (!IsCurrentPositionValid(_xCurrentPosition, _yCurrentPosition - 1))
                        return false;
                    _yCurrentPosition--;
                    return true;
                case Direction.West:
                    if (!IsCurrentPositionValid(_xCurrentPosition - 1, _yCurrentPosition))
                        return false;
                    _xCurrentPosition--;
                    return true;
                case Direction.Undefined:
                    return false;
                
                default:
                    return false;
            }
        }

        public bool TryLeft()
        {
            if (!IsCommandValid(Command.Left))
                return false;
            
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

            return true;
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