using RobotSimulatorLibrary.Interfaces;
using RobotSimulatorLibrary.RobotStates;

namespace RobotSimulatorLibrary.Factories
{
    static class StateFactory
    {
        public static IState CreateTurned(IRobot robot)
        {
            return new Turned(robot,CalculatorFactory.CreateForActiveCalculator(robot));
        }
        public static IState CreateMoved(IRobot robot)
        {
            return new Moved(robot,CalculatorFactory.CreateForActiveCalculator(robot));
        }
        public static IState CreatePlaced(IRobot robot)
        {
            return new Placed(robot,CalculatorFactory.CreateForActiveCalculator(robot));
        }
        public static IState CreateInactive(IRobot robot)
        {
            return new Inactive(robot,CalculatorFactory.CreateForActiveCalculator(robot));
        }   
    }
}
