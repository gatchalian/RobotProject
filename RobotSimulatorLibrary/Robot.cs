using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using RobotSimulatorLibrary.Calculators.Visitors;
using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Factories;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.RobotStates;

namespace RobotSimulatorLibrary
{
    public class Robot:IRobot
    {
        private IDisplayConsole _displayConsole;
        private IState _currentState;
        public ITable Table { get; private set; }
        public Position.Position CurrentPosition { get; private set; }
        public int LateralSpeed { get; private set; }
        public Robot(ITable table,int lateralSpeed,IDisplayConsole displayConsole)
        {
            Table = table;
            LateralSpeed = lateralSpeed;
            _currentState = StateFactory.CreateInactive(this);
            _displayConsole = displayConsole;
        }
        public void Execute(ICommand command)
        {
            if(command==null)
                throw new ArgumentException(nameof(command));
            _currentState.Execute(command);
        }

        public Position.Position GetReport()
        {
            if (CurrentPosition == null)
            {
                _displayConsole.ShowMessage(StringConstants.RobotNotInPlace);
                return CurrentPosition;
            }
            _displayConsole.ShowMessage($"POSITION x:{CurrentPosition.Location.X} y:{CurrentPosition.Location.Y} f:{CurrentPosition.Direction}");
            return CurrentPosition;
        }

        public void SetCurrentPosition(Position.Position position)
        {
            if (IsNewPositionValid(position))
            {
                CurrentPosition = position;
            }
        }

        public void SetCurrentState(IState state)
        {
            _currentState = state;
        }

        private bool IsNewPositionValid(Position.Position position)
        {
            return position != null && IsInTableBounds(position);
        }

        private bool IsInTableBounds(Position.Position position)
        {
            return position.Location.X <= Table.Width && 
                   position.Location.X >= 0 &&
                   position.Location.Y >= 0 &&
                   position.Location.Y <= Table.Height;
        }
    }
}
