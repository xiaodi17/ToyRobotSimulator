using ToyRobotSimulator.Robot.Robot;
using ToyRobotSimulator.Robot.Tabletop;
using Xunit;

namespace ToyRobotSimulator.Test
{
    public class RobotReportCommandTest
    {
        [Fact]
        public void RobotReportWithoutPlace()
        {
            var robot = new ToyRobot(new TabletopMap());
            var isReportCommandValid = robot.IsCommandValid(Command.Report);
            
            Assert.False(isReportCommandValid);
        }

        [Fact]
        public void RobotReportAfterPlace()
        {
            var robot = new ToyRobot(new TabletopMap());
            robot.TryPlace("place 0,0,north");
            var report = robot.Report();
            Assert.Equal("X: 0, Y: 0, Facing: North", report);
        }
    }
}