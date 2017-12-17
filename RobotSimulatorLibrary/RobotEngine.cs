using System;
using Autofac;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Commands.CommandParsers;
using RobotSimulatorLibrary.Factories;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary
{

    public class RobotEngine:IRobotEngine
    {
        private readonly IRobot _robot;
        private readonly CommandBroker _commandBroker;
        public RobotEngine(CommandBroker commandBroker,IRobot robot)
        {
            _robot = robot;
            _commandBroker = commandBroker;
        }

        public void Execute(string input)
        {
            if(input==null)
                throw new ArgumentException(nameof(input));
            _commandBroker.ResetParsers(RegistrationService.Container.ResolveKeyed<ICommandParser>(nameof(PlaceParser)));
           var result= _commandBroker.GetCommand(input);
            if(result.found)
                _robot.Execute(result.command);
        }
    }
}
