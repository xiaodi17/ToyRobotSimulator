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
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            var rotateLeftCommand = robot.TryLeft();
            var rotateRightCommand = robot.TryRight();
            
            //Assert
            Assert.False(rotateLeftCommand);
            Assert.False(rotateRightCommand);
        }
        
        [Fact]
        public void RotateAfterPlace()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            robot.TryPlace("place 0,0,north");
            var rotateLeftCommand = robot.TryLeft();
            var rotateRightCommand = robot.TryRight();
            
            //Assert
            Assert.True(rotateLeftCommand);
            Assert.True(rotateRightCommand);
        }
    }
}