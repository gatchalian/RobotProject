using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RobotSimulatorLibrary;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.Position;
using Xunit;

namespace RobotSimulatorTest
{
    public class RobotTest
    {
        [Fact]
        public void WhenGetReportCalledAndCurrentPositionIsNull()
        {
            var mockTable = new Mock<ITable>();
            var displayConsole = new Mock<IDisplayConsole>();
            var robot=new Robot(mockTable.Object,1,displayConsole.Object);
            var position=robot.GetReport();
            displayConsole.Verify(dc=>dc.ShowMessage(It.IsAny<string>()));
            Assert.Null(position);
        }

        [Fact]
        public void WhenGetReportCalledAndCurrentPositionIsSetAndValid()
        {
            var table = new Table(5, 5);
            var displayConsole = new Mock<IDisplayConsole>();
            var robot = new Robot(table, 1, displayConsole.Object);
            robot.SetCurrentPosition(new Position(new Location(1,1), Direction.North));
            Assert.Equal(1,robot.CurrentPosition.Location.X);
            Assert.Equal(1, robot.CurrentPosition.Location.Y);
            Assert.Equal(Direction.North, robot.CurrentPosition.Direction);
        }

        [Fact]
        public void WhenGetReportCalledAndCurrentPositionIsSetAndInValid()
        {
            var table=new Table(5,5);
            var displayConsole = new Mock<IDisplayConsole>();
            var robot = new Robot(table, 1, displayConsole.Object);
            robot.SetCurrentPosition(new Position(new Location(6, 6), Direction.North));
            var position = robot.GetReport();
            Assert.Null(position);
        }
    }
}
