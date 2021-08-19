namespace ToyRobotSimulator.Robot.Robot
{
    public interface IRobot
    {
        bool TryPlace(string command);

        bool TryMove();

        void Left();

        void Right();

        string Report();

        bool IsCommandValid(Command command);
    }
}