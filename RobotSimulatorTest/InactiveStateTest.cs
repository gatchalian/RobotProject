using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RobotSimulatorLibrary;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.RobotStates;
using Xunit;
using Xunit.Sdk;

namespace RobotSimulatorTest
{
    public class InactiveStateTest
    {
        [Fact]
        public void WhenInactiveGetReportIsCalled()
        {
            var mockRobot = new Mock<IRobot>();
            var mockCalculator = new Mock<ICalculator>();
            var inactive=new Inactive(mockRobot.Object,mockCalculator.Object);
            inactive.GetReport();
            mockRobot.Verify(robot=>robot.GetReport());
        }

        [Fact]
        public void WhenInactiveExecueIsCalledWithNullCommand()
        {
            var mockRobot = new Mock<IRobot>();
            var mockCalculator = new Mock<ICalculator>();
            var inactive = new Inactive(mockRobot.Object, mockCalculator.Object);
            Assert.Throws<ArgumentException>(() => inactive.Execute(null));
        }


        [Fact]
        public void WhenInactiveExecueIsCalledWithNotNullCommand()
        {
            var mockRobot = new Mock<IRobot>();
            var mockCommand = new Mock<ICommand>();
            var mockCalculator = new Mock<ICalculator>();
            var inactive = new Inactive(mockRobot.Object, mockCalculator.Object);
            inactive.Execute(mockCommand.Object);
            mockCalculator.Verify(calc=>calc.GetPositionAndState(It.IsAny<ICommand>()));
        }

        [Fact]
        public void WhenInactiveExecueIsCalledWithNotNullCommandAndNullPositionIsNull()
        {
            var mockRobot = new Mock<IRobot>();
            var mockCommand = new Mock<ICommand>();
            var mockCalculator = new Mock<ICalculator>();
            var inactive = new Inactive(mockRobot.Object, mockCalculator.Object);
            inactive.Execute(mockCommand.Object);
            mockCalculator.Verify(calc => calc.GetPositionAndState(It.IsAny<ICommand>()));
        }

    }
}
