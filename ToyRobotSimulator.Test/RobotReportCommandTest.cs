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
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            var isReportCommandValid = robot.IsCommandValid(Command.Report);
            
            
            //Assert
            Assert.False(isReportCommandValid);
        }

        [Fact]
        public void RobotReportAfterPlace()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            robot.TryPlace("place 0,0,north");
            var report = robot.Report();
            
            //Assert
            Assert.Equal("X: 0, Y: 0, Facing: North", report);
        }
    }
}