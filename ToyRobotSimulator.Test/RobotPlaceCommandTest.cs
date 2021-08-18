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
        public void Place_Command_Initial_Invalid()
        {
            //Arrange
            var invalidPlaceCommands = new List<string>()
            {
                "place",
                "place 0,0",
                // "place,0,0,north",
                "place 0,0,",
                "place 0,0,north,0"
            };

            //Act
            foreach (var command in invalidPlaceCommands)
            {
                var isValid = _toyRobot.TryPlace(command);
                
                //Assert
                Assert.False(isValid);
            }
        }

        [Fact]
        public void Place_Without_Facing_Direction_After_Robot_Placed_down()
        {
            var robot = new ToyRobot(new TabletopMap());
            var firstCommand = robot.TryPlace("place 0,0,north");

            var secondCommand = robot.TryPlace("place 1,1");
            
            Assert.True(firstCommand);
            Assert.True(secondCommand);

        }
    }
}