using ToyRobotSimulator.Robot.Robot;
using ToyRobotSimulator.Robot.Tabletop;
using Xunit;

namespace ToyRobotSimulator.Test
{
    public class RobotRotateCommandTest
    {
        [Fact]
        public void RotateWithoutPlace()
        {
            var robot = new ToyRobot(new TabletopMap());
            var rotateLeftCommand = robot.TryLeft();
            var rotateRightCommand = robot.TryLeft();
            
            Assert.False(rotateLeftCommand);
            Assert.False(rotateRightCommand);
        }
        
        [Fact]
        public void RotateAfterPlace()
        {
            var robot = new ToyRobot(new TabletopMap());
            robot.TryPlace("place 0,0,north");
            var rotateLeftCommand = robot.TryLeft();
            var rotateRightCommand = robot.TryLeft();
            
            Assert.True(rotateLeftCommand);
            Assert.True(rotateRightCommand);
        }
    }
}