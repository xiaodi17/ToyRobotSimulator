namespace ToyRobotSimulator.Robot.Robot
{
    public interface IRobot
    {
        bool TryPlace(string command);

        void Move();

        void Left();

        void Right();

        string Report();

        bool IsCommandValid(Command command);
    }
}