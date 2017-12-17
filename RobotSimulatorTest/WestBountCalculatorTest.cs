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
    public class WestBountCalculatorTest
    {
        [Fact]
        public void WhenGetLocationWithWestDirection()
        {
            var mockLocationCalc = new Mock<ILocationCalculator>();
            var westBound = new WestBound(mockLocationCalc.Object);
            var result = westBound.GetLocation(new Position(new Location(1, 1), Direction.West), 1);
            Assert.Equal(0, result.location.X);
            Assert.Equal(1, result.location.Y);
        }

        [Fact]
        public void WhenGetLocationEastDirection()
        {
            var mockLocationCalc = new Mock<ILocationCalculator>();
            var westBound = new WestBound(mockLocationCalc.Object);
            var result = westBound.GetLocation(new Position(new Location(1, 1), Direction.East), 1);
            Assert.Equal(1, result.location.X);
            Assert.Equal(1, result.location.Y);
            Assert.Equal(false, result.found);
        }

        [Fact]
        public void WhenGetLocationNorthDirection()
        {
            var mockLocationCalc = new Mock<ILocationCalculator>();
            var westBound = new WestBound(mockLocationCalc.Object);
            var result = westBound.GetLocation(new Position(new Location(1, 1), Direction.North), 1);
            Assert.Equal(1, result.location.X);
            Assert.Equal(1, result.location.Y);
            Assert.False(result.found);
        }

        [Fact]
        public void WhenGetLocationSouthDirection()
        {
            var mockLocationCalc = new Mock<ILocationCalculator>();
            var westBound = new WestBound(mockLocationCalc.Object);
            var result = westBound.GetLocation(new Position(new Location(1, 1), Direction.South), 1);
            Assert.Equal(1, result.location.X);
            Assert.Equal(1, result.location.Y);
            Assert.False(result.found);
        }
    }
}
