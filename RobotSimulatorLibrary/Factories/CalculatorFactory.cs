using RobotSimulatorLibrary.Calculators;
using RobotSimulatorLibrary.Calculators.Visitors;
using RobotSimulatorLibrary.Calculators.Visitors.Location;
using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Factories
{
    static class CalculatorFactory
    {
        public static ICalculator CreateForActiveCalculator(IRobot robot)
        {
            return new PositionCalculatorVisitor(robot, CreateLeftPositionCalculator(robot));
        }

        public static ICalculator CreateForInactiveCalculator(IRobot robot)
        {
            return new PositionCalculatorVisitor(robot, CreatePlacePositionCalculator(robot));
        }

        private static ICalculator CreateLeftPositionCalculator(IRobot robot)
        {
            return new LeftPositionCalculator(robot, CreateRightPositionCalculator(robot));
        }
        private static ICalculator CreateRightPositionCalculator(IRobot robot)
        {
            return new RightPositionCalculator(robot, CreateMovePositionCalculator(robot));
        }
        private static ICalculator CreateMovePositionCalculator(IRobot robot)
        {
            return new MovePositionCalculator(robot, CreatePlacePositionCalculator(robot),new NorthBound(new EastBound(new SouthBound(new WestBound(null)))));
        }
        private static ICalculator CreatePlacePositionCalculator(IRobot robot)
        {
            return new PlacePositionCalculator(robot, CreateReportPosCalculator(robot));
        }

        private static ICalculator CreateReportPosCalculator(IRobot robot)
        {
            return new ReportVisitor(robot,null);
        }


    }
}
