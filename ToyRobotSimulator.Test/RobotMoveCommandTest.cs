using ToyRobotSimulator.Robot.Robot;
using ToyRobotSimulator.Robot.Tabletop;
using Xunit;

namespace ToyRobotSimulator.Test
{
    public class RobotMoveCommandTest
    {
        [Fact]
        public void MoveCommandInitialInvalid()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());

            //Assert
            Assert.False(robot.IsCommandValid(Command.Move));
        }

        [Fact]
        public void MoveAfterPlaceValid()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            robot.Place("place 0,0,north");
            robot.Move();
            
            //Assert
            Assert.True(robot.IsCommandValid(Command.Move));
            Assert.Equal((0, 1), robot.GetRobotCurrentPosition());
        }
        
        [Fact]
        public void MoveOutOfBoundSouthWestCornerInvalid()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            robot.Place("place 0,0,south");
            robot.Move();
            
            //Assert
            Assert.Equal((0, 0), robot.GetRobotCurrentPosition());
            
            //Act
            robot.Place("place 0,0,west");
            robot.Move();
            
            //Assert
            Assert.Equal((0, 0), robot.GetRobotCurrentPosition());
        }

        [Fact]
        public void MoveOutOfBoundNorthWestCornerInvalid()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            robot.Place("place 0,5,north");
            robot.Move();
            
            //Assert
            Assert.Equal((0, 5), robot.GetRobotCurrentPosition());
            
            //Act
            robot.Place("place 0,5,west");
            robot.Move();
            
            //Assert
            Assert.Equal((0, 5), robot.GetRobotCurrentPosition());
        }
        
        [Fact]
        public void MoveOutOfBoundNorthEastCornerInvalid()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            robot.Place("place 5,5,north");
            robot.Move();
            
            //Assert
            Assert.Equal((5, 5), robot.GetRobotCurrentPosition());
            
            //Act
            robot.Place("place 5,5,east");
            robot.Move();
            
            //Assert
            Assert.Equal((5, 5), robot.GetRobotCurrentPosition());
        }
        
        [Fact]
        public void MoveOutOfBoundSouthEaSTtCornerInvalid()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            robot.Place("place 5,0,east");
            robot.Move();
            
            //Assert
            Assert.Equal((5, 0), robot.GetRobotCurrentPosition());
            
            //Act
            robot.Place("place 5,0,south");
            robot.Move();
            
            //Assert
            Assert.Equal((5, 0), robot.GetRobotCurrentPosition());
        }
    }
}