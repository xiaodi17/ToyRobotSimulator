namespace ToyRobotSimulator.Robot.Message
{
    public class RobotMessage
    {
        public const string INVALID_COMMAND = "Invalid command: Please use a valid command";
        public const string ROBOT_NOT_PLACED = "Invalid command: You have to use place command to place robot on the tabletop before using other commands";
        public const string ROBOT_OUT_OF_BOUND = "Invalid command: Robot cannot be out of bound";
        public const string ROBOT_INVALID_DIRECTION = "Invalid command: Robot needs a direction to move forward";
        public const string ROBOT_INVALID_PLACE = "Invalid command: Robot needs to be placed with a direction";
        public const string ROBOT_SIMULATOR_INSTRUCTION = "Toy Robot Simulator. \n\tPlease follow the command instructions: \n\t" +
                                                          " - PLACE X,Y,Direction: Place robot on the table top at (X, Y) position with facing direction. \n\t" +
                                                          "where X, Y are integers range from 0-5 \n\t" +
                                                          "Direction can be South, North, East, and West. \n\t " +
                                                          " - MOVE: Move robot forward facing the current direction. \n\t" +
                                                          " - LEFT: Rotate robot to the left. \n\t" +
                                                          " - RIGHT: Rotate robot to the right. \n\t" +
                                                          " - REPORT: Announce the current position. \n\t" +
                                                          " - EXIT: Terminate the program";
    }
}