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
    public class MovePositionCalculatorTest
    {
        [Fact]
        public void WhenGetPositionAndStateWithCommandNull()
        {
            var mockCommand = new Mock<ICommand>();
            var mockRobot = new Mock<IRobot>();
            var mockCalculator = new Mock<ICalculator>();
            var mockILocationCalculator =new Mock<ILocationCalculator>();
            var leftPositionCalculator = new MovePositionCalculator(mockRobot.Object, mockCalculator.Object,mockILocationCalculator.Object);
            Assert.Throws<ArgumentException>(() => leftPositionCalculator.GetPositionAndState(null));
        }

        [Fact]
        public void WhenGetPositionAndStateMoveFacingNorth()
        {
            var mockRobot = new Mock<IRobot>();
            mockRobot.SetupGet(r => r.CurrentPosition).Returns(new Position(new Location(1, 1), Direction.North));
            mockRobot.SetupGet(r => r.LateralSpeed).Returns(1);
            var mockCalculator = new Mock<ICalculator>();
            var mockLocationCalculator = new Mock<ILocationCalculator>();
            
            mockLocationCalculator.Setup(lc => lc.GetLocation(It.IsAny<Position>(), It.IsAny<int>()))
                .Returns(GetResult());
            var movePositionCalculator=new MovePositionCalculator(mockRobot.Object,mockCalculator.Object,mockLocationCalculator.Object);
            var result=movePositionCalculator.GetPositionAndState(new Move());
            mockLocationCalculator.Verify(lc=>lc.GetLocation(It.IsAny<Position>(),It.IsAny<int>()));
        }

        private (Location location, bool found) GetResult()
        {
            return (new Location(1,2),true);
        }


        [Fact]
        public void WhenProcessReportCommand()
        {
            var mockLocationCalculator = new Mock<ILocationCalculator>();
            var mockRobot = new Mock<IRobot>();
            mockRobot.Setup(r => r.GetReport());
            mockRobot.SetupGet(r => r.CurrentPosition).Returns(new Position(new Location(1, 1), Direction.West));
            var mockCalculator = new Mock<ICalculator>();
            var movePositionCalculator = new MovePositionCalculator(mockRobot.Object, mockCalculator.Object,mockLocationCalculator.Object);
            movePositionCalculator.ProcessReportCommand();
            mockRobot.Verify(r => r.GetReport());
        }
    }
}
