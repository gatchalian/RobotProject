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
    public class PlacePositionCalculatorTest
    {
        [Fact]
        public void WhenGetPositionAndStatePlaceFacingNorth()
        {
            var mockRobot = new Mock<IRobot>();
            mockRobot.SetupGet(r => r.Table).Returns(new Table(5, 5));
            mockRobot.SetupGet(r => r.CurrentPosition).Returns(new Position(new Location(1, 1), Direction.North));
            mockRobot.SetupGet(r => r.LateralSpeed).Returns(1);
            var mockCalculator = new Mock<ICalculator>();
            var placePositionCalculator = new PlacePositionCalculator(mockRobot.Object, mockCalculator.Object);
            var result = placePositionCalculator.GetPositionAndState(new Place(){Position = new Position(new Location(1,1),Direction.North )});
            Assert.Equal(1,result.position.Location.X);
            Assert.Equal(1, result.position.Location.Y);
            Assert.Equal(Direction.North,result.position.Direction);
        }

        [Fact]
        public void WhenGetPositionAndStateNotPlaceFacingNorth()
        {
            var mockRobot = new Mock<IRobot>();
            mockRobot.SetupGet(r => r.CurrentPosition).Returns(new Position(new Location(1, 1), Direction.North));
            mockRobot.SetupGet(r => r.LateralSpeed).Returns(1);
            var mockCalculator = new Mock<ICalculator>();
            mockCalculator.Setup(c => c.GetPositionAndState(It.IsAny<ICommand>()));
            var placePositionCalculator = new PlacePositionCalculator(mockRobot.Object, mockCalculator.Object);
            var result = placePositionCalculator.GetPositionAndState(new Move() { Position = new Position(new Location(1, 1), Direction.North) });
            mockCalculator.Verify(c=>c.GetPositionAndState(It.IsAny<ICommand>()));
        }
    }
}
