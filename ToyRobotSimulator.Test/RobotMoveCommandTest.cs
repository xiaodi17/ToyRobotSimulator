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
            
            //Act
            var initialMoveCommand = robot.TryMove();
            
            //Assert
            Assert.False(initialMoveCommand);
        }

        [Fact]
        public void MoveAfterPlaceValid()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            var placeCommand = robot.TryPlace("place 0,0,north");
            var moveCommand = robot.TryMove();
            
            //Assert
            Assert.True(placeCommand);
            Assert.True(moveCommand);
        }
        
        [Fact]
        public void MoveOutOfBoundSouthWestCornerInvalid()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            robot.TryPlace("place 0,0,south");
            var firstMoveCommand = robot.TryMove();
            
            robot.TryPlace("place 0,0,west");
            var secondMoveCommand = robot.TryMove();
            
            //Assert
            Assert.False(firstMoveCommand);
            Assert.False(secondMoveCommand);
        }

        [Fact]
        public void MoveOutOfBoundNorthWestCornerInvalid()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            robot.TryPlace("place 0,5,north");
            var firstMoveCommand = robot.TryMove();
            
            robot.TryPlace("place 0,5,west");
            var secondMoveCommand = robot.TryMove();
            
            //Assert
            Assert.False(firstMoveCommand);
            Assert.False(secondMoveCommand);
        }
        
        [Fact]
        public void MoveOutOfBoundNorthEastCornerInvalid()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            robot.TryPlace("place 5,5,north");
            var firstMoveCommand = robot.TryMove();
            
            robot.TryPlace("place 5,5,east");
            var secondMoveCommand = robot.TryMove();
            
            //Assert
            Assert.False(firstMoveCommand);
            Assert.False(secondMoveCommand);
        }
        
        [Fact]
        public void MoveOutOfBoundSouthEaSTtCornerInvalid()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            robot.TryPlace("place 5,0,east");
            var firstMoveCommand = robot.TryMove();
            
            robot.TryPlace("place 5,0,south");
            var secondMoveCommand = robot.TryMove();
            
            //Assert
            Assert.False(firstMoveCommand);
            Assert.False(secondMoveCommand);
        }
    }
}