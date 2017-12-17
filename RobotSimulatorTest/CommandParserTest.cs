using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Moq;
using RobotSimulatorLibrary;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Commands.CommandParsers;
using RobotSimulatorLibrary.Commands.Concrete;
using RobotSimulatorLibrary.Factories;
using RobotSimulatorLibrary.Interfaces;
using Xunit;

namespace RobotSimulatorTest
{
    public class CommandParserTest
    {

        [Fact]
        public void WhenPlaceStringValidParameterReceivedGetCommandMethodIsCalled()
        {
            var commandParser = new CommandBroker();
            var mockCommandParser = new Mock<ICommandParser>();
            commandParser.ResetParsers(mockCommandParser.Object);
            var result = commandParser.GetCommand("place 0,0,NORTH");
            mockCommandParser.Verify(calc=>calc.GetCommand(It.IsAny<string>(),It.IsAny<string>()));
        }

        [Fact]
        public void WhenPlaceStringValidParameterReceived()
        {
            RegistrationService.Register();
            var commandParser = RegistrationService.Container.Resolve<CommandBroker>();
            commandParser.ResetParsers(RegistrationService.Container.ResolveKeyed<ICommandParser>(nameof(PlaceParser)));
            var result=commandParser.GetCommand("place 0,0,NORTH");
           Assert.Equal(typeof(Place), result.command.GetType());
        }

        [Fact]
        public void WhenPlaceStringInvalidDirectionReceived()
        {
            RegistrationService.Register();
            var commandParser = RegistrationService.Container.Resolve<CommandBroker>();
            commandParser.ResetParsers(RegistrationService.Container.ResolveKeyed<ICommandParser>(nameof(PlaceParser)));
            var result = commandParser.GetCommand("place 0,0,NORT");
            Assert.Null(result.command);
        }

        [Fact]
        public void WhenMoveStringReceived()
        {
            RegistrationService.Register();
            var commandParser = RegistrationService.Container.Resolve<CommandBroker>();
            commandParser.ResetParsers(RegistrationService.Container.ResolveKeyed<ICommandParser>(nameof(PlaceParser)));
            var result=commandParser.GetCommand("move");
            Assert.Equal(typeof(Move), result.command.GetType());
        }

        [Fact]
        public void WhenLeftStringReceived()
        {
            RegistrationService.Register();
            var commandParser = RegistrationService.Container.Resolve<CommandBroker>();
            commandParser.ResetParsers(RegistrationService.Container.ResolveKeyed<ICommandParser>(nameof(PlaceParser)));
            var result=commandParser.GetCommand("left");
            Assert.Equal(typeof(Left), result.command.GetType());
        }
        [Fact]
        public void WhenRightStringReceived()
        {
            RegistrationService.Register();
            var commandParser = RegistrationService.Container.Resolve<CommandBroker>();
            commandParser.ResetParsers(RegistrationService.Container.ResolveKeyed<ICommandParser>(nameof(PlaceParser)));
            var result=commandParser.GetCommand("right");
            Assert.Equal(typeof(Right), result.command.GetType());
        }

        [Fact]
        public void WhenReportStringReceived()
        {
            RegistrationService.Register();
            var commandParser = RegistrationService.Container.Resolve<CommandBroker>();
            commandParser.ResetParsers(RegistrationService.Container.ResolveKeyed<ICommandParser>(nameof(PlaceParser)));
            var result=commandParser.GetCommand("report");
            Assert.Equal(typeof(Report), result.command.GetType());
        }

        [Fact]
        public void WhenInvalidCommandStringReceived()
        {
            RegistrationService.Register();
            var commandParser = RegistrationService.Container.Resolve<CommandBroker>();
            commandParser.ResetParsers(RegistrationService.Container.ResolveKeyed<ICommandParser>(nameof(PlaceParser)));
            var result = commandParser.GetCommand("anthing");
            Assert.Null(result.command);
        }
    }
}
