using RobotSimulatorLibrary.Interfaces;

namespace RobotSimulatorLibrary.Calculators.Visitors.Location
{
    public abstract class BaseBound:ILocationCalculator
    {
        protected ILocationCalculator LocationCalculator;

        protected BaseBound(ILocationCalculator locationCalculator)
        {
            LocationCalculator = locationCalculator;
        }

        public abstract (Position.Location location, bool found) GetLocation(Position.Position position, int lateralSpeed);
    }
}
