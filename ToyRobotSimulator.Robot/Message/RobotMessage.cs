namespace ToyRobotSimulator.Robot.Message
{
    public class RobotMessage
    {
        public const string INVALID_COMMAND = "Invalid command: Please use a valid command";
        public const string ROBOT_NOT_PLACED = "Invalid place command: You have to use place command to place robot on the tabletop before using other commands";
        public const string ROBOT_OUT_OF_BOUND = "Invalid move command: Robot cannot be out of bound";
        public const string ROBOT_INVALID_DIRECTION = "Invalid move command: Robot needs a direction to move forward";
    }
}