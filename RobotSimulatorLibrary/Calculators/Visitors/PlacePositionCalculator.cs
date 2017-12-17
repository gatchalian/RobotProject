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
            return command.GetType().Name == nameof(Place) 
                ? (command.Position, StateFactory.CreatePlaced(Robot), true) 
                : Calculator.GetPositionAndState(command);
        }
    }
}
