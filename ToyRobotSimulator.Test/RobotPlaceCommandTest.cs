using System;
using System.Collections.Generic;
using ToyRobotSimulator.Robot.Robot;
using ToyRobotSimulator.Robot.Tabletop;
using Xunit;

namespace ToyRobotSimulator.Test
{
    public class RobotPlaceCommandTest
    {
        private readonly ToyRobot _toyRobot = new ToyRobot(new TabletopMap());
        
        [Fact]
        public void PlaceCommandInitialInvalid()
        {
            //Arrange
            var invalidPlaceCommands = new List<string>()
            {
                "place",
                "place 0,0",
                "place,0,0,north",
                "place 0,0,",
                "place 0,0,north,0"
            };

            //Act
            foreach (var command in invalidPlaceCommands)
            {
                _toyRobot.Place(command);
                
                //Assert
                Assert.False(_toyRobot.IsRobotPlaceDown());
            }
        }

        [Fact]
        public void PlaceWithoutFacingDirectionAfterRobotPlacedDown()
        {
            //Arrange
            var robot = new ToyRobot(new TabletopMap());
            
            //Act
            robot.Place("place 0,0,north");
            robot.Place("place 1,1");
            
            //Assert
            Assert.True(robot.IsRobotPlaceDown());
            Assert.Equal(Direction.North, robot.GetDirection());
        }
    }
}