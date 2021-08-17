namespace ToyRobotSimulator.Robot.Robot
{
    public interface IRobot
    {
        void Place(string command);

        void Move();

        void Left();

        void Right();

        string Report();

        bool IsValidCommand(Command command);
    }
}