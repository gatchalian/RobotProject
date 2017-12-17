using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RobotSimulatorLibrary;
using RobotSimulatorLibrary.Calculators.Visitors.Location;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.Position;
using Xunit;

namespace RobotSimulatorTest
{
    public class NorthBoundCalculatorTest
    {
        [Fact]
        public void WhenGetLocationWithNorthDirection()
        {
            var mockLocationCalc = new Mock<ILocationCalculator>();
            var northBound = new NorthBound(mockLocationCalc.Object);
            var result = northBound.GetLocation(new Position(new Location(1, 1), Direction.North), 1);
            Assert.Equal(1, result.location.X);
            Assert.Equal(2, result.location.Y);
        }

        [Fact]
        public void WhenGetLocationWestDirection()
        {
            var mockLocationCalc = new Mock<ILocationCalculator>();
            mockLocationCalc.Setup(c => c.GetLocation(It.IsAny<Position>(), 1));
            var northBound = new NorthBound(mockLocationCalc.Object);
            var result = northBound.GetLocation(new Position(new Location(1, 1), Direction.West), 1);
            mockLocationCalc.Verify(calc => calc.GetLocation(It.IsAny<Position>(), 1));
        }

        [Fact]
        public void WhenGetLocationSouthDirection()
        {
            var mockLocationCalc = new Mock<ILocationCalculator>();
            mockLocationCalc.Setup(c => c.GetLocation(It.IsAny<Position>(), 1));
            var northBound = new NorthBound(mockLocationCalc.Object);
            var result = northBound.GetLocation(new Position(new Location(1, 1), Direction.South), 1);
            mockLocationCalc.Verify(calc => calc.GetLocation(It.IsAny<Position>(), 1));
        }

        [Fact]
        public void WhenGetLocationEastDirection()
        {
            var mockLocationCalc = new Mock<ILocationCalculator>();
            mockLocationCalc.Setup(c => c.GetLocation(It.IsAny<Position>(), 1));
            var northBound = new NorthBound(mockLocationCalc.Object);
            var result = northBound.GetLocation(new Position(new Location(1, 1), Direction.East), 1);
            mockLocationCalc.Verify(calc => calc.GetLocation(It.IsAny<Position>(), 1));
        }
    }
}
