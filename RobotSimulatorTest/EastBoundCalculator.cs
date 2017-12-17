using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Moq;
using RobotSimulatorLibrary;
using RobotSimulatorLibrary.Calculators.Visitors.Location;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.Position;
using Xunit;

namespace RobotSimulatorTest
{
    public class EastBoundCalculator
    {
        [Fact]
        public void WhenGetLocationWithEastDirection()
        {
            var mockLocationCalc = new Mock<ILocationCalculator>();
            var eastBound=new EastBound(mockLocationCalc.Object);
            var result=eastBound.GetLocation(new Position(new Location(1,1), Direction.East), 1);
            Assert.Equal(2, result.location.X);
            Assert.Equal(1, result.location.Y);
        }

        [Fact]
        public void WhenGetLocationWestDirection()
        {
            var mockLocationCalc = new Mock<ILocationCalculator>();
            mockLocationCalc.Setup(c => c.GetLocation(It.IsAny<Position>(), 1));
            var eastBound = new EastBound(mockLocationCalc.Object);
            var result = eastBound.GetLocation(new Position(new Location(1, 1), Direction.West), 1);
            mockLocationCalc.Verify(calc => calc.GetLocation(It.IsAny<Position>(), 1));
        }

        [Fact]
        public void WhenGetLocationNorthDirection()
        {
            var mockLocationCalc = new Mock<ILocationCalculator>();
            mockLocationCalc.Setup(c => c.GetLocation(It.IsAny<Position>(), 1));
            var eastBound = new EastBound(mockLocationCalc.Object);
            var result = eastBound.GetLocation(new Position(new Location(1, 1), Direction.North), 1);
            mockLocationCalc.Verify(calc => calc.GetLocation(It.IsAny<Position>(), 1));
        }

        [Fact]
        public void WhenGetLocationSouthDirection()
        {
            var mockLocationCalc = new Mock<ILocationCalculator>();
            mockLocationCalc.Setup(c => c.GetLocation(It.IsAny<Position>(), 1));
            var eastBound = new EastBound(mockLocationCalc.Object);
            var result = eastBound.GetLocation(new Position(new Location(1, 1), Direction.South), 1);
            mockLocationCalc.Verify(calc => calc.GetLocation(It.IsAny<Position>(), 1));
        }
    }
}
