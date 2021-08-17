namespace ToyRobotSimulator.Robot.Tabletop
{
    public class Tabletop
    {
        private int X_AxisLength;
        private int Y_AxisLength;

        public Tabletop()
        {
            X_AxisLength = 6;
            Y_AxisLength = 6;
        }

        public Tabletop(int xAxisLength, int yAxisLength)
        {
            X_AxisLength = xAxisLength;
            Y_AxisLength = yAxisLength;
        }
    }
}