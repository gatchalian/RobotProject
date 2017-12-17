using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RobotSimulatorLibrary;
using RobotSimulatorLibrary.Calculators.Visitors;
using RobotSimulatorLibrary.Commands.Concrete;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.Position;
using Xunit;

namespace RobotSimulatorTest
{
    public class ReportVisitorTest
    {
        [Fact]
        public void WhenGetPositionAndStateReportCommand()
        {
            var mockRobot = new Mock<IRobot>();
            mockRobot.SetupGet(r => r.CurrentPosition).Returns(new Position(new Location(1, 1), Direction.North));
            mockRobot.SetupGet(r => r.LateralSpeed).Returns(1);
            var mockCalculator = new Mock<ICalculator>();
            mockCalculator.Setup(c => c.GetPositionAndState(It.IsAny<ICommand>()));
            var reportVisitor = new ReportVisitor(mockRobot.Object, mockCalculator.Object);
            var result = reportVisitor.GetPositionAndState(new Report() { Position = new Position(new Location(1, 1), Direction.North) });
            Assert.Null(result.position);
            Assert.False(result.isMatched);
        }

        [Fact]
        public void WhenGetPositionAndStateNoneReportCommand()
        {
            var mockRobot = new Mock<IRobot>();
            mockRobot.SetupGet(r => r.CurrentPosition).Returns(new Position(new Location(1, 1), Direction.North));
            mockRobot.SetupGet(r => r.LateralSpeed).Returns(1);
            var mockCalculator = new Mock<ICalculator>();
            mockCalculator.Setup(c => c.GetPositionAndState(It.IsAny<ICommand>()));
            var reportVisitor = new ReportVisitor(mockRobot.Object, mockCalculator.Object);
            var result = reportVisitor.GetPositionAndState(new Right() { Position = new Position(new Location(1, 1), Direction.North) });
            Assert.Null(result.position);
            Assert.False(result.isMatched);
        }
    }
}
