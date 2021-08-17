namespace ToyRobotSimulator.Robot.Tabletop
{
    public class TabletopMap
    {
        public int XAxisLength { get; private set; }
        public int YAxisLength { get; private set; }

        public TabletopMap()
        {
            XAxisLength = 6;
            YAxisLength = 6;
        }

        public TabletopMap(int xAxisLength, int yAxisLength)
        {
            XAxisLength = xAxisLength;
            YAxisLength = yAxisLength;
        }
    }
}