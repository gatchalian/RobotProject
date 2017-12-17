using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using RobotSimulatorLibrary.Calculators.Visitors.Location;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Commands.Concrete;
using RobotSimulatorLibrary.Factories;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.RobotStates;

namespace RobotSimulatorLibrary.Calculators.Visitors
{
    public class MovePositionCalculator : BasePositionCalculator
    {
        private readonly ILocationCalculator _locationCalculator;
        public MovePositionCalculator(IRobot robot,ICalculator calculator,ILocationCalculator locationCalculator) : base(robot,calculator)
        {
            _locationCalculator = locationCalculator;
        }

        public override (Position.Position position, IState state, bool isMatched) GetPositionAndState(ICommand command)
        {
            if(command==null)
                throw new ArgumentException(nameof(command));
            if (command.GetType().Name != nameof(Move)) return Calculator.GetPositionAndState(command);
            var newLocation = GetNewLocation(Robot.CurrentPosition);
            return (new Position.Position(newLocation, Robot.CurrentPosition.Direction), StateFactory.CreateMoved(Robot), true);
        }


        private Position.Location GetNewLocation(Position.Position position)
        {
            var result= _locationCalculator.GetLocation(position, Robot.LateralSpeed);
            var location = result.location;
            return location;
        }

    }
}
