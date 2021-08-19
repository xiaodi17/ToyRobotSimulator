using System;
using System.Text.RegularExpressions;
using ToyRobotSimulator.Robot.Message;
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

        public bool IsRobotPlaceDown()
        {
            if (!IsCurrentPositionValid(_xCurrentPosition, _yCurrentPosition))
                return false;

            if (_direction == Direction.Undefined)
                return false;

            return true;
        }

        public (int xPosition, int yPosition) GetRobotCurrentPosition()
        {
            return (_xCurrentPosition, _yCurrentPosition);
        }

        public void Place(string command)
        {
            var stringWithoutWhitespaces = Regex.Replace(command.Substring(5), @"\s+", "");
            var commandDetails = stringWithoutWhitespaces.Split(',');

            if (commandDetails.Length < 2 || commandDetails.Length > 3)
            {
                Console.WriteLine(RobotMessage.INVALID_COMMAND);
                return;
            }

            if (!int.TryParse(commandDetails[0], out var xMovePosition))
            {
                Console.WriteLine(RobotMessage.INVALID_COMMAND);
                return;
            }

            if (!int.TryParse(commandDetails[1], out var yMovePosition))
            {
                Console.WriteLine(RobotMessage.INVALID_COMMAND);
                return;
            }

            if (commandDetails.Length == 3)
            {
                if (string.IsNullOrEmpty(commandDetails[2]))
                {
                    Console.WriteLine(RobotMessage.INVALID_COMMAND);
                    return;
                }
                
                if (!Enum.TryParse(commandDetails[2], true, out Direction direction))
                {
                    if (direction == Direction.Undefined)
                    {
                        Console.WriteLine(RobotMessage.INVALID_COMMAND);
                        return;
                    }
                }
                _direction = direction;
            }

            if (!IsCurrentPositionValid(xMovePosition, yMovePosition))
            {
                Console.WriteLine(RobotMessage.ROBOT_OUT_OF_BOUND);
                return;
            }

            if (IsCurrentPositionValid(xMovePosition, yMovePosition) && _direction == Direction.Undefined)
            {
                Console.WriteLine(RobotMessage.ROBOT_INVALID_PLACE);
                return;
            }

            _xCurrentPosition = xMovePosition;
            _yCurrentPosition = yMovePosition;
        }

        public void Move()
        {
            switch (_direction)
            {
                case Direction.East:
                    if (!IsCurrentPositionValid(_xCurrentPosition + 1, _yCurrentPosition))
                    {
                        Console.WriteLine(RobotMessage.ROBOT_OUT_OF_BOUND);
                        return;
                    }
                    
                    _xCurrentPosition++;
                    break;
                
                case Direction.North:
                    if (!IsCurrentPositionValid(_xCurrentPosition, _yCurrentPosition + 1))
                    {
                        Console.WriteLine(RobotMessage.ROBOT_OUT_OF_BOUND);
                        return;
                    }
                    
                    _yCurrentPosition++;
                    break;
                
                case Direction.South:
                    if (!IsCurrentPositionValid(_xCurrentPosition, _yCurrentPosition - 1))
                    {
                        Console.WriteLine(RobotMessage.ROBOT_OUT_OF_BOUND);
                        return;
                    }
                    
                    _yCurrentPosition--;
                    break;
                
                case Direction.West:
                    if (!IsCurrentPositionValid(_xCurrentPosition - 1, _yCurrentPosition))
                    {
                        Console.WriteLine(RobotMessage.ROBOT_OUT_OF_BOUND);
                        return;
                    }
                    
                    _xCurrentPosition--;
                    break;
                
                case Direction.Undefined:
                    Console.WriteLine(RobotMessage.ROBOT_INVALID_DIRECTION);
                    break;
                
            }
        }

        public void Left()
        {
            if (!IsCommandValid(Command.Left))
            {
                Console.WriteLine(RobotMessage.ROBOT_NOT_PLACED);
                return;
            }
            
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
                case Direction.Undefined:
                    break;
            }
        }

        public void Right()
        {
            if (!IsCommandValid(Command.Left))
            {
                Console.WriteLine(RobotMessage.ROBOT_NOT_PLACED);
                return;
            }

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
                case Direction.Undefined:
                    break;
            }
        }

        public void Report()
        {
            if (!IsCurrentPositionValid(_xCurrentPosition, _yCurrentPosition))
            {
                Console.WriteLine(RobotMessage.ROBOT_NOT_PLACED);
                return;
            }
                
            Console.WriteLine($"X: {_xCurrentPosition}, Y: {_yCurrentPosition}, Facing: {_direction}");
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