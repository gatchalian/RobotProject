using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RobotSimulatorLibrary;
using RobotSimulatorLibrary.Calculators.Visitors;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Commands.Concrete;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.Position;
using Xunit;

namespace RobotSimulatorTest
{
    public class RightPostionCalculatorTest
    {
        [Fact]
        public void WhenGetPositionAndStateWithCommandNull()
        {
            var mockCommand = new Mock<ICommand>();
            var mockRobot = new Mock<IRobot>();
            var mockCalculator = new Mock<ICalculator>();
            var rightPositionCalculator = new RightPositionCalculator(mockRobot.Object, mockCalculator.Object);
            Assert.Throws<ArgumentException>(() => rightPositionCalculator.GetPositionAndState(null));
        }

        [Fact]
        public void WhenGetPositionAndStateWithCommandRightFacingEast()
        {
            var command = new Right();
            var mockRobot = new Mock<IRobot>();
            mockRobot.SetupGet(r => r.CurrentPosition).Returns(new Position(new Location(1, 1), Direction.East));
            var mockCalculator = new Mock<ICalculator>();
            var rightPositionCalculator = new RightPositionCalculator(mockRobot.Object, mockCalculator.Object);
            var result = rightPositionCalculator.GetPositionAndState(command);
            Assert.Equal(Direction.South, result.position.Direction);
        }
        [Fact]
        public void WhenGetPositionAndStateWithCommandRightFacingNorth()
        {
            var command = new Right();
            var mockRobot = new Mock<IRobot>();
            mockRobot.SetupGet(r => r.CurrentPosition).Returns(new Position(new Location(1, 1), Direction.North));
            var mockCalculator = new Mock<ICalculator>();
            var rightPositionCalculator = new RightPositionCalculator(mockRobot.Object, mockCalculator.Object);
            var result = rightPositionCalculator.GetPositionAndState(command);
            Assert.Equal(Direction.East, result.position.Direction);
        }
        [Fact]
        public void WhenGetPositionAndStateWithCommandRightFacingWest()
        {
            var command = new Right();
            var mockRobot = new Mock<IRobot>();
            mockRobot.SetupGet(r => r.CurrentPosition).Returns(new Position(new Location(1, 1), Direction.West));
            var mockCalculator = new Mock<ICalculator>();
            var rightPositionCalculator = new RightPositionCalculator(mockRobot.Object, mockCalculator.Object);
            var result = rightPositionCalculator.GetPositionAndState(command);
            Assert.Equal(Direction.North, result.position.Direction);
        }

        [Fact]
        public void WhenGetPositionAndStateWithCommandRightFacingSouth()
        {
            var command = new Right();
            var mockRobot = new Mock<IRobot>();
            mockRobot.SetupGet(r => r.CurrentPosition).Returns(new Position(new Location(1, 1), Direction.South));
            var mockCalculator = new Mock<ICalculator>();
            var rightPositionCalculator = new RightPositionCalculator(mockRobot.Object, mockCalculator.Object);
            var result = rightPositionCalculator.GetPositionAndState(command);
            Assert.Equal(Direction.West, result.position.Direction);
        }

        [Fact]
        public void WhenGetPositionAndStateWithCommandNonRight()
        {
            var command = new Left();
            var mockRobot = new Mock<IRobot>();
            mockRobot.SetupGet(r => r.CurrentPosition).Returns(new Position(new Location(1, 1), Direction.West));
            var mockCalculator = new Mock<ICalculator>();
            mockCalculator.Setup(c => c.GetPositionAndState(It.IsAny<ICommand>()));
            var rightPositionCalculator = new RightPositionCalculator(mockRobot.Object, mockCalculator.Object);
            var result = rightPositionCalculator.GetPositionAndState(command);
            mockCalculator.Verify(c => c.GetPositionAndState(It.IsAny<ICommand>()));
        }

        [Fact]
        public void WhenProcessReportCommand()
        {
            var mockRobot = new Mock<IRobot>();
            mockRobot.Setup(r => r.GetReport());
            mockRobot.SetupGet(r => r.CurrentPosition).Returns(new Position(new Location(1, 1), Direction.West));
            var mockCalculator = new Mock<ICalculator>();
            var rightPositionCalculator = new RightPositionCalculator(mockRobot.Object, mockCalculator.Object);
            rightPositionCalculator.ProcessReportCommand();
            mockRobot.Verify(r => r.GetReport());
        }
    }
}
