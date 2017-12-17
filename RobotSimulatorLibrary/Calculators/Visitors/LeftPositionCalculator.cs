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
    public class LeftPositionCalculator:BasePositionCalculator
    {
        public LeftPositionCalculator(IRobot robot,ICalculator calculator) : base(robot,calculator)
        {
        }
        public override (Position.Position position, IState state, bool isMatched) GetPositionAndState(ICommand command)
        {
            if(command==null)
                throw  new ArgumentException(nameof(command));
            if (command.GetType().Name != nameof(Left)) return Calculator.GetPositionAndState(command);

            var newDirection = GetNewDirection(Robot.CurrentPosition.Direction);
            return (new Position.Position(new Position.Location(Robot.CurrentPosition.Location.X, Robot.CurrentPosition.Location.Y), newDirection),StateFactory.CreateTurned(Robot), true);
        }
        private Direction GetNewDirection(Direction direction)
        {
            var result =(int) direction;
            result--;
            if (result < 0)
            {
                 result = 3;
            }
            return (Direction) result;
        }
    }
}
