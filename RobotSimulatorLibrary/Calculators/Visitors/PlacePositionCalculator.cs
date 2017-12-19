using RobotSimulatorLibrary.Commands;
using RobotSimulatorLibrary.Commands.Concrete;
using RobotSimulatorLibrary.Factories;
using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.RobotStates;

namespace RobotSimulatorLibrary.Calculators.Visitors
{
    public class PlacePositionCalculator:BasePositionCalculator
    {

        public PlacePositionCalculator(IRobot robot,ICalculator calculator):base(robot,calculator)
        {
        }


        public override (Position.Position position, IState state, bool isMatched) GetPositionAndState(ICommand command)
        {
            if (command.GetType().Name == nameof(Place)
                && command.Position.Location.Y >=0
                && command.Position.Location.X >= 0
                && command.Position.Location.Y<=Robot.Table.Height 
                && command.Position.Location.X<=Robot.Table.Width)
            {
                return (command.Position, StateFactory.CreatePlaced(Robot), true);
            }
            return Calculator.GetPositionAndState(command);
        }
    }
}
