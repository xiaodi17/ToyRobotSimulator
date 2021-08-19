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

            //Assert
            Assert.False(robot.IsCommandValid(Command.Left));
            Assert.False(robot.IsCommandValid(Command.Right));
        }
        
        [Fact]
        public void RotateLeftAfterPlace()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            robot.Place("place 0,0,north");
            robot.Left();

            //Assert
            Assert.True(robot.IsCommandValid(Command.Left));
            Assert.Equal(Direction.West, robot.GetDirection());
        }
        
        [Fact]
        public void RotateRightAfterPlace()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            robot.Place("place 0,0,north");
            robot.Right();

            //Assert
            Assert.True(robot.IsCommandValid(Command.Right));
            Assert.Equal(Direction.East, robot.GetDirection());
        }
    }
}