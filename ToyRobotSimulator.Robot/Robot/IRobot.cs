namespace ToyRobotSimulator.Robot.Robot
{
    public interface IRobot
    {
        bool TryPlace(string command);

        bool TryMove();

        bool TryLeft();

        bool TryRight();

        string Report();

        bool IsCommandValid(Command command);
    }
}